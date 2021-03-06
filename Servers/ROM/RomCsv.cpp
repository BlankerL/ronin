#include "StdAfx.h"
#include "RomCsv.h"


CRomCsv::CRomCsv(std::string& l_sub) : CRomMessage(l_sub)
{
}

CRomCsv::CRomCsv(const char* pMsg, int size) : CRomMessage(pMsg, size)
{
}

CRomCsv::CRomCsv(char cmd)
{
	SetAt(ROMFIELDS::CSV_COMMAND, cmd);
}

CRomCsv::CRomCsv(const CRomCsv& csv) : CRomMessage(const_cast<CRomCsv&>(csv).Message())
{
}

CRomCsv::CRomCsv(void)
{
}

CRomCsv::~CRomCsv(void)
{
}

