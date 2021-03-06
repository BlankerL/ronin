/*******************************************************************************
 *
 * Copyright (c) 2005 by RONIN CAPITAL, LLC
 *
 * All Rights Reserved. 
 *******************************************************************************/
/*
 * MERRILL.cpp : Defines the class behaviors for the application.
 *
 *
 * History
 *
 * date        user	       comment
 * -------     --------    -----------------------------------------------------
 * 10/18/05    joel        Initial version of MERRILL exchange interface (stocks)
 *
 *******************************************************************************/

#include "stdafx.h"
#include "MERRILL.h"

#include "MainFrm.h"
#include "ChildFrm.h"
#include "MERRILLDoc.h"
#include "MERRILLView.h"

#include "ConnectionFrame.h"
#include "TrafficDoc.h"
#include "TrafficView.h"

#include "MERRILLFixSession.h"
#include "MERRILLHandler.h"
#include "ExchangeStatus.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMERRILLApp

BEGIN_MESSAGE_MAP(CMERRILLApp, CWinApp)
	//{{AFX_MSG_MAP(CMERRILLApp)
	ON_COMMAND(ID_APP_ABOUT, OnAppAbout)
	ON_COMMAND(IDM_LOGOUT, OnLogout)
	ON_COMMAND(IDM_RESET_OUTGOING, OnResetOutgoing)
	ON_COMMAND(IDM_RESET_INCOMING, OnResetIncoming)
	ON_COMMAND(IDM_CLEAR_OUTGOING, OnClearOutgoing)
	ON_COMMAND(IDM_CLEAR_INCOMING, OnClearIncoming)
	ON_COMMAND(IDM_TAGGLE_DISPLAY, OnTaggleDisplay)
	ON_UPDATE_COMMAND_UI(IDM_TAGGLE_DISPLAY, OnUpdateTaggleDisplay)
	ON_COMMAND(IDM_RELOAD_TAGS, OnReloadTags)
	//}}AFX_MSG_MAP
	// Standard file based document commands
	ON_COMMAND(ID_FILE_NEW, CWinApp::OnFileNew)
	ON_COMMAND(ID_FILE_OPEN, CWinApp::OnFileOpen)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMERRILLApp construction

CMERRILLApp::CMERRILLApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CMERRILLApp object

CMERRILLApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CMERRILLApp initialization

BOOL CMERRILLApp::InitInstance()
{
	if (!AfxSocketInit())
	{
		AfxMessageBox(IDP_SOCKETS_INIT_FAILED);
		return FALSE;
	}

	AfxEnableControlContainer();

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

#ifdef _AFXDLL
	Enable3dControls();			// Call this when using MFC in a shared DLL
#else
	Enable3dControlsStatic();	// Call this when linking to MFC statically
#endif

	// Change the registry key under which our settings are stored.
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization.
	SetRegistryKey(_T("Local AppWizard-Generated Applications"));

	LoadStdProfileSettings(0);  // Load standard INI file options (including MRU)

	// Register the application's document templates.  Document templates
	//  serve as the connection between documents, frame windows and views.

	CMultiDocTemplate* pDocTemplate;
	pDocTemplate = new CMultiDocTemplate(
		IDR_MERRILLTYPE,
		RUNTIME_CLASS(CMERRILLDoc),
		RUNTIME_CLASS(CChildFrame), // custom MDI child frame
		RUNTIME_CLASS(CMERRILLView));
	AddDocTemplate(pDocTemplate);

	CMultiDocTemplate* pTrafficDocTemplate;
	pTrafficDocTemplate = new CMultiDocTemplate(
		IDR_TRAFFICTYPE,
		RUNTIME_CLASS(CTrafficDoc),
		RUNTIME_CLASS(CConnectionFrame), // custom MDI child frame
		RUNTIME_CLASS(CTrafficView));
	AddDocTemplate(pTrafficDocTemplate);

	// create main MDI Frame window
	CMainFrame* pMainFrame = new CMainFrame;
	if (!pMainFrame->LoadFrame(IDR_MAINFRAME))
		return FALSE;
	m_pMainWnd = pMainFrame;

	// Parse command line for standard shell commands, DDE, file open
	CCommandLineInfo cmdInfo;
	ParseCommandLine(cmdInfo);

	// Dispatch commands specified on the command line
//	if (!ProcessShellCommand(cmdInfo))
//		return FALSE;

	// The main window has been initialized, so show and update it.
	m_Name	= "MERRILL";

	m_DatFile = m_lpCmdLine;
	if(!CExchangeApp::InitInstance())
		return FALSE;

	// create client window
	CConnectionFrame	*pNewFrame;
	CMERRILLDoc			*pDoc;
	POSITION			pos;

	pDoc = (CMERRILLDoc *)pDocTemplate->CreateNewDocument();
	pNewFrame = (CConnectionFrame *)(pDocTemplate->CreateNewFrame(pDoc, NULL));
	pNewFrame->SetTitle("Client Connections");
	pDocTemplate->InitialUpdateFrame(pNewFrame, pDoc);
	pNewFrame->Restore();
	if ((pos = pDoc->GetFirstViewPosition()))
	{
  		m_pClientView = (CMERRILLView *)pDoc->GetNextView(pos);
		m_Clients.SetList(&m_pClientView->m_List);
	}

	// create exchange window
	pDoc = (CMERRILLDoc *)pDocTemplate->CreateNewDocument();
	pNewFrame = (CConnectionFrame *)(pDocTemplate->CreateNewFrame(pDoc, NULL));
	pNewFrame->SetTitle("Exchange Connection");
	pDocTemplate->InitialUpdateFrame(pNewFrame, pDoc);
	pNewFrame->Restore();
	if ((pos = pDoc->GetFirstViewPosition()))
	{
  		m_pExchangeView = (CMERRILLView *)pDoc->GetNextView(pos);
		m_pExchangeView->CreateTimer(15000);
	}

	// create error, status, and traffic windows
	CTrafficDoc	*pTrafficDoc;

	pTrafficDoc = (CTrafficDoc *)pTrafficDocTemplate->CreateNewDocument();
	pNewFrame = (CConnectionFrame *)(pTrafficDocTemplate->CreateNewFrame(pTrafficDoc, NULL));
	pNewFrame->SetTitle("Order Traffic");
	pTrafficDocTemplate->InitialUpdateFrame(pNewFrame, pTrafficDoc);
	pNewFrame->Restore();
	if ((pos = pTrafficDoc->GetFirstViewPosition()))
  		m_pTrafficView = (CTrafficView *)pTrafficDoc->GetNextView(pos);

	pTrafficDoc = (CTrafficDoc *)pTrafficDocTemplate->CreateNewDocument();
	pNewFrame = (CConnectionFrame *)(pTrafficDocTemplate->CreateNewFrame(pTrafficDoc, NULL));
	pNewFrame->SetTitle("Status Messages");
	pTrafficDocTemplate->InitialUpdateFrame(pNewFrame, pTrafficDoc);
	pNewFrame->Restore();
	if ((pos = pTrafficDoc->GetFirstViewPosition()))
  		m_pStatusView = (CTrafficView *)pTrafficDoc->GetNextView(pos);

	pTrafficDoc = (CTrafficDoc *)pTrafficDocTemplate->CreateNewDocument();
	pNewFrame = (CConnectionFrame *)(pTrafficDocTemplate->CreateNewFrame(pTrafficDoc, NULL));
	pNewFrame->SetTitle("Error Messages");
	pTrafficDocTemplate->InitialUpdateFrame(pNewFrame, pTrafficDoc);
	pNewFrame->Restore();
	if ((pos = pTrafficDoc->GetFirstViewPosition()))
  		m_pErrorView = (CTrafficView *)pTrafficDoc->GetNextView(pos);

	m_pServer	= new CServer();									// create server
	m_pHandler	= new CMERRILLHandler();								// create order handler
	try {
		m_pExchange	= new CMERRILLFixSession();								// create fix session
	}
	catch(CFixSessionException&) {
		ProcessErrorEx(MODE_ERR_NOTIFY,"MERRILL App", "Initialization of FIX session failed.");
		return FALSE;
	}
	m_pStatus	= new CExchangeStatus();								// create status handler
	AddHost((CHostConnection*) CreateHost());						// connection to exchange
	m_pServer->StartListening();									// start listening for client connections

	// init static vars
	COrder::Init();
	UpdateRunDate();

	// The main window has been initialized, so show and update it.
	pMainFrame->ShowWindow(SW_SHOWNORMAL);
	pMainFrame->Restore();
	pMainFrame->UpdateWindow();
	pMainFrame->ShowWindow(m_nCmdShow);

	return TRUE;
}

void CMERRILLApp::UpdateClients()
{
	if (m_pClientView)
		m_pClientView->m_List.Update();
}

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
		// No message handlers
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

// App command to run the dialog
void CMERRILLApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}


void CMERRILLApp::OnReloadTags()
{
	((CMERRILLFixSession*)m_pExchange)->InitializeFixCustomTags();
}
