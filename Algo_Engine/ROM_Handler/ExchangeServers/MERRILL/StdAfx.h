/*******************************************************************************
 *
 * Copyright (c) 2005 by RONIN CAPITAL, LLC
 *
 * All Rights Reserved. 
 *******************************************************************************/
/*
 * stdafx.h : include file for standard system include files,
 * or project specific include files that are used frequently, but
 * are changed infrequently
 *
 *
 * History
 *
 * date        user	       comment
 * -------     --------    -----------------------------------------------------
 * 10/18/05    joel        Initial version of MERRILL exchange interface (stocks)
 *
 *******************************************************************************/

#if !defined(AFX_STDAFX_H__333E7DA2_D301_404A_94F4_63ABD9A6C5BB__INCLUDED_)
#define AFX_STDAFX_H__333E7DA2_D301_404A_94F4_63ABD9A6C5BB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers

#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <afxdisp.h>        // MFC Automation classes

#ifndef _AFX_NO_DB_SUPPORT
#include <afxdb.h>			// MFC ODBC database classes
#endif // _AFX_NO_DB_SUPPORT

#ifndef _AFX_NO_DAO_SUPPORT
#include <afxdao.h>			// MFC DAO database classes
#endif // _AFX_NO_DAO_SUPPORT

#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <afxsock.h>		// MFC socket extensions

#pragma warning (disable : 4786)

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__333E7DA2_D301_404A_94F4_63ABD9A6C5BB__INCLUDED_)
