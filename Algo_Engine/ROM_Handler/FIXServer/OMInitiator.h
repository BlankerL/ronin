/* -*- C++ -*- */
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

#ifndef OM_INITIATOR_H
#define OM_INITIATOR_H

#include "Fields.h"
#include "OMSession.h"
#include "SessionSettings.h"
#include "Exceptions.h"
#include "Mutex.h"
#include <iostream>
#include <set>
#include <map>
#include <string>

using namespace FIX;

namespace OM
{
  class Client;

  /*! \addtogroup user
   *  @{
   */
  /**
   * Base for classes which act as an initiator for establishing connections.
   *
   * Most users will not need to implement one of these.  The default
   * SocketInitiator implementation will be used in most cases.
   */
  class Initiator
  {
  public:
    Initiator( Application&, const SessionSettings& settings ) throw( ConfigError& );
    virtual ~Initiator();

    /// Start initiator.
    bool start();
    /// Stop initiator.
    void stop() { onStop(); }
    /*Restart initiator*/
    bool restart();

    Session* getSession( Session::Responder& );

  protected:
    Application& getApplication() { return m_application; }
    void setConnected( const SessionID&, bool );
    bool isConnected( const SessionID& );
    void connect();

  private:
    /// Implemented to start connecting to targets.
    virtual bool onStart( const SessionSettings& ) = 0;
    /// Implemented to stop a running initiator.
    virtual void onStop() = 0;
    /// Implemented to connect a session to its target.
    virtual bool doConnect( const SessionID&, const Dictionary& ) = 0;

    static void* startThread( void* p );

    typedef std::set<SessionID> SessionIDs;
    typedef std::map<SessionID, int> SessionState;
    typedef std::auto_ptr<Session> SessionPtr;

    SessionPtr m_pSession;
    SessionIDs m_connected;
    SessionIDs m_disconnected;
    SessionState m_sessionState;

    Application& m_application;
    SessionSettings m_settings;
    Mutex m_mutex;
  };
  /*! @} */
}

#endif 
