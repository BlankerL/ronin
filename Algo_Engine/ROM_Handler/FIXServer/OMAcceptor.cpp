/* ====================================================================
 * The QuickFIX Software License, Version 1.0
 *
 * Copyright (c) 2001 ThoughtWorks, Inc.  All rights
 * reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in
 *    the documentation and/or other materials provided with the
 *    distribution.
 *
 * 3. The end-user documentation included with the redistribution,
 *    if any, must include the following acknowledgment:
 *       "This product includes software developed by
 *        ThoughtWorks, Inc. (http://www.thoughtworks.com/)."
 *    Alternately, this acknowledgment may appear in the software itself,
 *    if and wherever such third-party acknowledgments normally appear.
 *
 * 4. The names "QuickFIX" and "ThoughtWorks, Inc." must
 *    not be used to endorse or promote products derived from this
 *    software without prior written permission. For written
 *    permission, please contact quickfix-users@lists.sourceforge.net.
 *
 * 5. Products derived from this software may not be called "QuickFIX",
 *    nor may "QuickFIX" appear in their name, without prior written
 *    permission of ThoughtWorks, Inc.
 *
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED.  IN NO EVENT SHALL THOUGHTWORKS INC OR
 * ITS CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF
 * USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT
 * OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 * ====================================================================
 */

#ifdef _MSC_VER
#pragma warning( disable : 4503 4355 4786 )
#include "stdafx.h"
#else
#include "config.h"
#endif

#include "OMAcceptor.h"
#include "Utility.h"
#include <algorithm>
#include <fstream>

namespace OM
{
	Acceptor::Acceptor( Application& application, FIX::MessageStoreFactory& factory,
                      const SessionSettings& settings )
    throw( ConfigError& )
    : m_application(application), m_settings(settings)
  {
    std::set<SessionID> sessions = settings.getSessions();
    std::set<SessionID>::iterator i;

    if(!sessions.size())
      throw ConfigError("No sessions defined");

    for(i = sessions.begin(); i != sessions.end(); ++i)
      {
        if(settings.get(*i).getString("ConnectionType") == "acceptor")
          {
            Dictionary dict = settings.get(*i);
            std::string url;
            if(dict.has("DataDictionary"))
              url = dict.getString("DataDictionary");

            UtcTimeOnly startTime;
            UtcTimeOnly endTime;
            try
            {
              startTime = UtcTimeOnlyConvertor::convert
                (settings.get(*i).getString("StartTime"));
              endTime = UtcTimeOnlyConvertor::convert
                (settings.get(*i).getString("EndTime"));
            }
            catch(FieldConvertError& e)
            {
              throw ConfigError(e.what());
            }

            m_pSession = SessionPtr(new Session(m_application, *i, startTime, endTime));
            m_application.onCreate(*i);
          }
      }
  }

  Acceptor::~Acceptor()
  {
  }

  Session* Acceptor::getSession( Session::Responder& responder )
  {
    try
      {
        if(m_pSession.get())
          {
            m_pSession->setResponder(&responder);
            return m_pSession.get();
          }
      }
    catch( FieldNotFound& ) {}
    return 0;
  }

  bool Acceptor::start()
  {
    m_mutex.lock();
    if(!thread_spawn(&startThread, this))
      m_mutex.unlock();

    return onStart(m_settings);
  }

  void* Acceptor::startThread( void* p )
  {
    Acceptor* pAcceptor = static_cast<Acceptor*>(p);
    pAcceptor->getApplication().onRun();
    pAcceptor->stop();
    pAcceptor->m_mutex.unlock();
    return 0;
  }
}
