// RecorderDoc.cpp : implementation of the CRecorderDoc class
//

#include "stdafx.h"
#include "DBRecorder.h"

#include "RecorderDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CRecorderDoc

IMPLEMENT_DYNCREATE(CRecorderDoc, CDocument)

BEGIN_MESSAGE_MAP(CRecorderDoc, CDocument)
	//{{AFX_MSG_MAP(CRecorderDoc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CRecorderDoc construction/destruction

CRecorderDoc::CRecorderDoc()
{
	// TODO: add one-time construction code here

}

CRecorderDoc::~CRecorderDoc()
{
}

BOOL CRecorderDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CRecorderDoc serialization

void CRecorderDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CRecorderDoc diagnostics

#ifdef _DEBUG
void CRecorderDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CRecorderDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CRecorderDoc commands
