using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

[Serializable]
public static class Utility
{
    public static void InvokeDelay(this MonoBehaviour mb, Action f, float delay)
    {
        mb.StartCoroutine(InvokeRoutine(f, delay));
    }

    private static IEnumerator InvokeRoutine(System.Action f, float delay)
    {
        yield return new WaitForSeconds(delay);
        f();
    }
}

[Serializable]
public class MainData
{
    public string password;
    public string panacure;
    public int players = 0;
    public int tracker = 0;
    public string round;
    public string nameA;
    public string nameB;
    public string nameC;
    public string nameD;
    public string nameE;
    public int creepy4 = 0;
    public int sane3 = 0;
    public string building;
    public string seedy;
    public int cured = 0;
    public int sciadv = 0;
    public string sci3;
    public int trigger35 = 0;
    public int devpage = 0;
    public string wolves;
    public string hunters;
    public string mayor;
    public string townname;
    public string heart;
    public int hearttotal;
    public int charitytotal = 0;
    public string uniturn;
    public string study;
    public string theme;
    public string pana;
    public string sym;
    public string hos;
    public int life = 0;
    public string fevervp;
    public string fevermoney;
    public string lycan;
    public string immort;
    public string final5;
    public string bar;
    public string uni;
    public int peeps = 0;
    public string mental;
    public string saneplayer;
    public string barin;
    public string charity;
    public string build;
    public string buildA;
    public string buildB;
    public string buildC;
    public string ba;
    public string bb;
    public string bc;
    public string inv;
    public string vial;
    public string ending;
    public string playtxt;
    public string ultimate;
    public string meet;
    public string allyA;
    public string allyB;
    public string allyC;
    public string allyD;
    public string allyE;
    public string memb;
    public string order;
    public string mission;
    public string bar1;
    public string bar2;
    public string bar3;
    public string bar4;
    public string bar5;
    public string fevercure;
    public string tempjournal;
    public string symp;
    public string pub;
    public string society;
    public string imm;
    public string letter;
    public string pa;
    public string pb;
    public string pc;
    public string pd;
    public string pe;
    public string let1;
    public string let2;
    public string let3;
    public string let4;
    public string let5;
    public string let6;
    public int exposeA = 0;
    public string goodcount;
    public string pAA;
    public string pBA;
    public string pCA;
    public string pDA;
    public string pEA;
    public int exposeB = 0;
    public string pAB;
    public string pBB;
    public string pCB;
    public string pDB;
    public string pEB;
    public int exposeC = 0;
    public string pAC;
    public string pBC;
    public string pCC;
    public string pDC;
    public string pEC;
    public string prosp;
    public int huntcount = 0;
    public string letterA;
    public string letterB;
    public string letterC;
    public string letA;
    public string letB;
    public string letC;
    public string refusaltoken;
    public string sick;
    public int playA = 0;
    public int playB = 0;
    public string huntreward;
    public string huntreward1;
    public string huntreward2;
    public string det1;
    public string killed;
    public string det2;
    public string det3;
    public string det4;
    public string tempinf;
    public int setinf = 0;
    public string lifeA;
    public string lifeB;
    public string lifeC;
    public string lifeD;
    public string lifeE;
    public string disease1;
    public int playC = 0;
    public int playD = 0;
    public int playE = 0;
    public string most;
    public string three5vp;
    public string gen2exp;
    public string hospsign;
    public string hospA;
    public int hospcount = 0;
    public string hospB;
    public string hospC;
    public string hospD;
    public string hospE;
    public string hospentry;
    public int trig = 0;
    public string disA;
    public string costA;
    public string typeA;
    public string cost2A;
    public string creationA;
    public string disB;
    public string tempcomp;
    public string tempcheck;
    public string typeB;
    public string typeC;
    public string typeD;
    public string typeE;
    public string costB;
    public string cost2B;
    public string creationB;
    public string disC;
    public string costC;
    public string cost2C;
    public string creationC;
    public string disD;
    public string costD;
    public string cost2D;
    public string creationD;
    public string disE;
    public string costE;
    public string church;
    public string intro;
    public string huntvp;
    public string confront;
    public string taxes;
    public string vialuse;
    public string randomplayer;
    public string randomname;
    public string gen1creep;
    public string gen1sane;
    public string vacation;
    public string eviltax;
    public string h1a;
    public string h1b;
    public string h2a;
    public string h2b;
    public string huntname;
    public string winner;
    public int timemistake = 0;
    public string tempdisease;
    public string huntnum;
    public string aide;
    public string amtoken;
    public string frenzy;
    public string disease2;
    public string midquote;
    public string cost2E;
    public string creationE;
    public string fever;
    public string mon;
    public string monster1;
    public string monster2;
    public string monster3;
    public string monster4;
    public string monster5;
    public string rew;
    public string reward1;
    public string reward2;
    public string reward3;
    public string reward4;
    public string reward5;
    public string reward6;
    public string reward7;
    public string reward8;
    public string hunttemp;
    public string hunt1a;
    public string hunt1b;
    public string hunt2a;
    public string hunt2b;
    public string hunt3a;
    public string hunt1c;
    public string h2c;
    public string huntbeast;
    public string effect;
    public string tempeffect;
    public string randrew;
    public string overrun;
    public string huntresult;
    public string direction;
    public int scoreA = 0;
    public int scoreB = 0;
    public int scoreC = 0;
    public int scoreD = 0;
    public int scoreE = 0;
    public int tcodgen1 = 0;
    public int hcount = 0;
    public int wcount = 0;
    public int twopage = 0;
    public int letterSetRandomize = 0;
    public string tempString;
    public int Progress = 0;
    //public string currentPassageName;
    //fear of Unknown
    public string newspaper;
    public int whpg = 0;
    public string _SetupImage;
    public int fp10vp = 0;
    public int fpresearch2 = 0;
    public int fpsanity3 = 0;
    public int fpcreepy3 = 0;
    public string kill;
    public string mobbed;
    public int mog = 0;
    public string forpg;
    public string witch1;
    public string brickvalue;
    public int revresolve = 0;
    public string revplot;
    public int crpg = 0;
    public string path4;
    public string witch;
    public string liber;
    public string conse;
    public string asupg;
    public string asylumup;
    public string did1;
    public string Gen2fate;
    public string wal;
    public int jail = 0;
    public string Gen2End;
    public int visit = 0;
    public int tensegood = 0;
    public int tensebad = 0;
    public int isooff = 0;
    public int ten = 0;
    public string walls;
    public int eor = 0;
    public int businesscount = 0;
    public int Acont = 0;
    public int Bcont = 0;
    public int Ccont = 0;
    public int Dcont = 0;
    public int Econt = 0;
    public int creature = 0;
    public int exped = 0;
    public string hunt;
    public string warden;
    public string junkpenalty;
    public int gen3pg = 0;
    public string weaponrew;
    public string reignsep;
    public string twcode;
    public string genericr;
    public string ch1;
    public string ch2;
    public int gen1 = 0;
    public int gen2 = 0;
    public string crownL;
    public string crownR;
    public string title;
    public string revenge;
    public string tempid;
    public int pay = 0;
    public int trial = 0;
    public int tempbs = 0;
    public string witch2;
    public string tension;
    public string crossroads;
    public string ex;
    public int dev = 0;
    public int busvp = 0;
    public int btemp = 0;
    public int pripg = 0;
    public string menname;
    public string mentype;
    public string them;
    public int pl3 = 0;
    public int pl4 = 0;
    public int pl5 = 0;
    public int pl2 = 0;
    public int counter = 0;
    public int pl1 = 0;
    public string witA;
    public string witB;
    public string witC;
    public string witD;
    public string witE;
    public string witA2;
    public string witB2;
    public string witC2;
    public string witD2;
    public string witE2;
    public string falsewitch;
    public int rum = 0;
    public int cursed = 0;
    public string plotA;
    public string plotB;
    public string plotC;
    public string plotD;
    public string plotE;
    public string journal1a;
    public string bribe;
    public string collab;
    public int smugA = 0;
    public int smugB = 0;
    public int smugC = 0;
    public int smugD = 0;
    public int smugE = 0;
    public int asylumcount = 0;
    public string control;
    public int id = 0;
    public string tempcreep;
    public string idA;
    public string idB;
    public string idC;
    public string idD;
    public string idE;
    public int carcount = 0;
    public int saltsp = 0;
    public string obsvp;
    public int creaturehelp = 0;
    public string wall;
    public int onecount = 0;
    public int Aconfirm = 0;
    public int plA = 0;
    public string tempname;
    public int Bconfirm = 0;
    public string plB;
    public int Cconfirm = 0;
    public string plC;
    public int Dconfirm = 0;
    public string plD;
    public int Econfirm;
    public string plE;
    public string fpfate;
    public string fate1;
    public string fate2;
    public string fate3;
    public string fate4;
    public string fate5;
    public string fate6;
    public string busm;
    public int bnc = 0;
    public string bhome;
    public int Av = 0;
    public int Bv = 0;
    public int Cv = 0;
    public int Dv = 0;
    public int Ev = 0;
    public string tempas;
    public string curecount;
    public string question;
    public string journal1b;
    public string journal1c;
    public string letter1a;
    public string letter1b;
    public string letter1c;
    public string journal2;
    public string letter2;
    public string journal3;
    public string letter3;
    public string xxxx;
    public string goal2nd;
    public string tempplot;
    public int token2a = 0;
    public int token2b = 0;
    public int token2c = 0;
    public int token2d = 0;
    public int token2e = 0;
    public string agiA;
    public string strA;
    public int hitA = 0;
    public string warriorA;
    public string agiB;
    public string active;
    public string target;
    public string tempstr;
    public string warriorB;
    public string strB;
    public string warriorC;
    public string strC;
    public string warriorD;
    public string strD;
    public string warriorE;
    public string strE;
    public string tempagi;
    public string agiC;
    public string agiD;
    public string agiE;
    public int temphit = 0;
    public int hitB = 0;
    public int hitC = 0;
    public int hitD = 0;
    public int hitE = 0;
    public int elimcount = 0;
    public int battlecount = 0;
    public int creepcount = 0;
    public string elim;
    public string forpg1;
    public string forpg2;
    public string forpg3;
    public string creepA;
    public string creepB;
    public string creepC;
    public string creepD;
    public string creepE;
    public string cureplayer;
    public string lib;
    public string asylumquestion;
    public string asymlump;
    public string token2;
    public int bribed = 0;
    public string wsuspect;
    public string witAI;
    public string witAI2;
    public string pointAI;
    public string hexAI;
    public int test = 0;
    public int next = 0;
    public int outcome = 0;
    public string quest1;
    public string quest2;
    public string quest3;
    public string quest4;
    public string psych;
    public string qu1;
    public string qu2;
    public string qu3;
    public string qu4;
    public string creaturecard;
    //ATimeofWar
    public int rumblings = 0;
    public int war = 0;
    public string warwinner;
    public string crest;
    public string warloser;
    public string figure;
    public string quarter;
    public int crazy = 0;
    public string barracksact;
    public string tmmasterwork;
    public string rumor;
    public string rumor1;
    public string rumor2;
    public string rumor6;
    public string opt1;
    public string opt2;
    public int nomore = 0;
    public int gunsbonus;
    public string barracks;
    public string sep;
    public int late = 0;
    public int pg13 = 0;
    public int ttset = 0;
    public int pg14 = 0;
    public string tmrepair;
    public string dox;
    public string tmnumber;
    public string takereact;
    public int martial = 0;
    public int martweapons = 0;
    public string sepinc1;
    public int wardestroy = 0;
    public int sabpage = 0;
    public string sepinc2;
    public string barn;
    public string accolade;
    public int pgGen3 = 0;
    public int iou = 0;
    public string wardetermine;
    public string sabotagee1;
    public int warpage2 = 0;
    public string moninc3;
    public string sepinc3;
    public string decbon;
    public string endchange;
    public string commtrigger;
    public string wlimit;
    public int onestcrown = 0;
    public int pea1 = 0;
    public int pea2 = 0;
    public int pea3 = 0;
    public int peac = 0;
    public int total = 0;
    public int search = 0;
    public string stasis;
    public string per;
    public string cont;
    public string master;
    public int buy = 0;
    public int silentA = 0;
    public int silentB = 0;
    public int silentC = 0;
    public int silentD = 0;
    public int silentE = 0;
    public string rumor3;
    public string benevolent;
    public string pageturn;
    public int release = 0;
    public int giants = 0;
    public string blame;
    public int th = 0;
    public int crowncount = 0;
    public int peacecount = 0;
    public string heat;
    public string bldg1;
    public string teaopt;
    public string royaladvisor;
    public string reigntemp;
    public int plareign = 0;
    public int rc = 0;
    public int plareigng = 0;
    public int plbreigng = 0;
    public int plcreigng = 0;
    public int pldreigng = 0;
    public int plereigng = 0;
    public int plareigne = 0;
    public int plbreigne = 0;
    public int plcreigne = 0;
    public int pldreigne = 0;
    public int plereigne = 0;
    public int reigning = 0;
    public string mostben;
    public string signincomm;
    public string ATOWStatue;
    public string gunschoice;
    public string gun1;
    public string gun2;
    public string destroy;
    public string sabo;
    public string bldg2;
    public string bldg3;
    public string sab1;
    public string sab2;
    public string platm;
    public string plbtm;
    public string plctm;
    public string pldtm;
    public string pletm;
    public string sepevent;
    public int barrackpen = 0;
    public string playersabotage1;
    public int advisorcount = 0;
    public string dueltype;
    public string duelsci;
    public string duelshot;
    public string duelwinner;
    public string duelloser;
    public string duelresult;
    public string defense;
    public string parasecret;
    public string milit;
    public string newmeat;
    public string famine;
    public string advise;
    public int r1 = 0;
    public int r2 = 0;
    public int r3 = 0;
    public int r4 = 0;
    public int r5 = 0;
    public int r6 = 0;
    public int r7 = 0;
    public int r8 = 0;
    public int r9 = 0;
    public int r10 = 0;
    public int r11 = 0;
    public int r12 = 0;
    public int r13 = 0;
    public int r14 = 0;
    public int r15 = 0;
    public int r16 = 0;
    public int Devastation1 = 0;
    public int University1 = 0;
    public int Hospital1 = 0;
    public int Prosperity1 = 0;
    public int Foreign = 0;
    public int Creature = 0;
    public int Privatized = 0;
    public int Martial1 = 0;
    public int MonarchReignIntro = 0;
    public int Peace1 = 0;
    public string feverheartnextPsg;
    public string S5HospA1nextPsg;
    public string HospitalNegativenextPsg;
    public string TaxesEventNoConfrontationnextPsg;
    public string Diseases2nextPsg;
    public string NoHospitalConsnextPsg;
    public string SymposiumMiddlenextPsg;
    public string HuntNorthnextPsg;
    public string HuntWestnextPsg;
    public string HuntSouthnextPsg;
    public string Gen1CreepyNonextPsg;
    public string Gen1SanityNonextPsg;
    public string Gen1Insanity_YesnextPsg;
    public string Gen1Insanity_Yes2nextPsg;
    public string HuntEastnextPsg;

    public string S4IsoBricknextpsg;
    public string Liberal2nextpsg;
    public string exponextpsg;
    public string Mobbed2nextpsg;
    public string SmugConsequencenextpsg;
    public string SmugEvent2Aanextpsg;
    public string EssentialConsnextpsg;
    public string FPFateAssignHubnextpsg;
    public string BusMeetCnextpsg;
    public string BusMeetBnextpsg;
    public string BusMeetAnextpsg;
    public string BusMeetDnextpsg;
    public string BusMeetEnextpsg;
    public string Payment1Hubnextpsg;
    public string SmugEvent2AContnextpsg;
    public string EssentialSalts1nextpsg;
    public string EssentialSalts1nextpsg2;
    public string EssentialSaltsNonextpsg;
    public string LiberalEvent2anextpsg;
    public string LiberalEvent2abnextpsg;
    public string AsylumTestResultsnextpsg;

    public string RumorD1nextPsg;
    public string RumorD2nextPsg;
    public string RumorD3nextPsg;
    public string RumorD4nextPsg;
    public string ResistSidesnextPsg;
    public string WarningIntronextPsg;
    public string ParadoxFirstnextPsg;
    public string OUTDATEDFirstParanextPsg;
    public string RumorD6ConfirmnextPsg;
    public string TTBarracksPenaltynextPsg;
}

[Serializable]
public class EndingsData
{
    public int index;
    public string endingsTitle;
    public StoryName storyName;
    public EndingsData()
    {
    }
    public EndingsData(int _index, string title, StoryName _storyName)
    {
        index = _index;
        endingsTitle = title;
        storyName = _storyName;
    }

}
[Serializable]
public class MainEnding
{
    public List<EndingsData> endingsDataList = new List<EndingsData>();

    public MainEnding()
    {

    }
    public MainEnding(int index, string title, StoryName storyName)
    {
        EndingsData endData = new EndingsData(index, title, storyName);
        endingsDataList.Add(endData);
    }
}

[Serializable]
public class LogBookTitleData
{
    public int index;
    public string logBookTitle;
    public LogBookTitleData()
    {
    }
    public LogBookTitleData(int _index, string title)
    {
        index = _index;
        logBookTitle = title;
    }

}

[Serializable]
public class LogBookTitle
{
    public List<LogBookTitleData> logBookTitlelist = new List<LogBookTitleData>();

    public LogBookTitle() { }

    public LogBookTitle(int _index, string title)
    {
        LogBookTitleData bookTitleData = new LogBookTitleData(_index, title);
        logBookTitlelist.Add(bookTitleData);
    }
}

[Serializable]
public class L_Book
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI location;
    public TextMeshProUGUI details;
    public Scrollbar scrollbar;
    public Image Icon;
}

[Serializable]
public class ItemObtainIcon
{
    public string englishIconName;
    public string spanishIconName;
    public string germanIconName;
    public string portugeseIconName;
    public string italianIconName;
    public string chineseIconName;
    public string japaneseIconName;
    public Sprite icon;
}

[Serializable]
public class TheCostOfDisease
{
    public int Id;
    public string identifier;
    public string EnglishName;
    public string SpanishName;
    public string GermanName;
    public string PortugeseName;
    public string ItalianName;
    public string ChineseName;
    public string JapaneseName;
    public string spriteName;
    public TheCostOfDisease() { }
    public TheCostOfDisease(int _Id, string _Identifier, string _EnglishName, string _SpanishName, string _GermanName, string _PortugeseName, string _ItalianName, string _ChineseName, string _JapaneseName, string _SpriteName)
    {
        Id = _Id;
        identifier = _Identifier;
        EnglishName = _EnglishName;
        SpanishName = _SpanishName;
        GermanName = _GermanName;
        PortugeseName = _PortugeseName;
        ItalianName = _ItalianName;
        ChineseName = _ChineseName;
        JapaneseName = _JapaneseName;
        spriteName = _SpriteName;
    }
}

[Serializable]
public class TheCostOfDiseaseData
{
    public List<TheCostOfDisease> TheCostOfDisease = new List<TheCostOfDisease>();
}

[Serializable]
public class EndOfGenerationProgreess
{
    public List<string> PassageName = new List<string>();
    public string[] Details;
    public string[] details2;
    public int Progress;
}

[Serializable]
public class HubData
{
    public string titleName;
    public string details;

    public HubData() { }

    public HubData(string title, string detail)
    {
        titleName = title;
        details = detail;
    }
}