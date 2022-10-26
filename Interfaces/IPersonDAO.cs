using Models;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IPersonDAO
    {
        bool DeletePerson(int id);
        List<Person> GetListPerson(string columnOrder = "ID");
        Person GetNewPerson();
        Person GetPersonByID(int id);
        Person InsertPerson(string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation);
        bool LoadFileExcel(List<(string Name, int Gender, DateTime DateOfBirth, string Cmnd, string Address)> listInput);
        bool UpdatePerson(int id, string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation);
    }
}