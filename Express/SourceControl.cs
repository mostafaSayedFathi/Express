using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SourceControl
{
    Source source;
    SourceDB sourceDB;
    private Boolean check;

    public Boolean insertSource(string name, string address, string EmployeeName1, string EmployeeName2, int phone1, int phone2, int phone3)
    {
        source = new Source();
        sourceDB = new SourceDB();
        source.setName(name);
        source.setEmployeeName1(EmployeeName1);
        source.setEmployeeName2(EmployeeName2);
        source.setAddress(address);
        source.setPhone1(phone1);
        source.setPhone2(phone2);
        source.setPhone3(phone3);
        check = sourceDB.checkSource(source);
        if (check == true)
        {
            return false;
        }
        else
        {
            sourceDB.insert(source);
            return true;
        }
    }

    public int selectID(string sourceName)
    {
        sourceDB = new SourceDB();
        source = new Source();
        source.setName(sourceName);
        return sourceDB.selectSourceId(source);
    }
}

