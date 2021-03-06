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

#include "OMSocketConnection.h"
#include "OMSocketAcceptor.h"
#include "SocketConnector.h"
#include "OMSocketInitiator.h"
#include "OMMessage.h"
#include "Utility.h"
#include "Log.h"

namespace OM
{
  SocketConnection::SocketConnection( SocketInitiator& i,
                                      const SessionID& sessionID, int s,
                                      SocketMonitor* pMonitor )
    : m_stream(s), m_parser(m_stream),
      m_pSession(i.getSession(*this)),
      m_pMonitor(pMonitor), m_pInitiator(&i)
  {
  }

  bool SocketConnection::send( const std::string& msg )
  {
		Log::Write( LOG_MESSAGE, "Sending " + msg );
		return socket_send(m_stream.getSocket(), msg.c_str(), msg.length());
  }

  void SocketConnection::disconnect()
  {
    if(m_pMonitor)
      m_pMonitor->drop(m_stream.getSocket());
  }

  void SocketConnection::connect()
  {
      if(m_pInitiator) {
        m_pInitiator->restart();
      }
  }

  bool SocketConnection::read( SocketConnector& s )
  {
    if(!m_pSession) return false;

	std::string msg;
 /*
	if (!readMessage(msg)) return false;
 */
	char buff[4096];
	memset( buff, 0, sizeof(buff) );
	if( ::recv( m_stream.getSocket(), buff, sizeof(buff)-1, 0 ) > 0 )
	{
		msg = buff;
		Log::Write( LOG_DEBUG, msg );
		Log::Write( LOG_DEBUG, m_buffer );
		m_buffer += msg;
		std::string::size_type pos;
		while( ( pos = m_buffer.find('\n') ) != std::string::npos )
		{
			msg = m_buffer.substr(0, pos + 1);
			m_buffer = m_buffer.substr(pos + 1);
			try
			{
				m_pSession->next(msg);
			} 
			catch(InvalidMessage&) 
			{}
		}
		return true;
	}
	else
	{
		// reconnect
		return false;
	}

    return true;
  }

  bool SocketConnection::read( SocketAcceptor& a, SocketServer& s )
  {
    std::string msg;
    try
      {
        if (!readMessage(msg)) return false;

        if( !m_pSession )
          m_pSession = a.getSession(*this);

        if( m_pSession )
          m_pSession->next(msg);
        else
          s.getMonitor().drop(m_stream.getSocket());
        return true;
      }
    catch( MessageParseError& )
      {
        s.getMonitor().drop(m_stream.getSocket());
      }
    catch( InvalidMessage& ) {}
    return true;
  }

  bool SocketConnection::readMessage(std::string& msg)
    throw(MessageParseError&)
  {
    int bytes = 0;
    if(!socket_fionread(m_stream.getSocket(), bytes))
      return false;

    try
      {
        return m_parser.readMessage( msg, bytes );
      }
    catch( MessageParseError& ) {}
    return true;
  }

  void SocketConnection::onTimeout()
  {
    if(m_pSession) m_pSession->next();
  }
} // namespace FIX
