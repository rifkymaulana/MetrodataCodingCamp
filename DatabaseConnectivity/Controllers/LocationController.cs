using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


class LocationController
{
    public void Menu()
    {
        CrudView crudView = new CrudView();
        Location location = new Location();
        LocationView locationView = new LocationView();
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    locationView.Create();
                    break;
                case 2:
                    locationView.GetAll(location.GetAll());
                    break;
                case 3:
                    locationView.GetById();
                    break;
                case 4:
                    locationView.Update();
                    break;
                case 5:
                    locationView.Delete();
                    break;
                case 9:
                    crudView.Menu();
                    break;
                default:
                    Message.InputOnlyMenu();
                    Message.ClickAnyKeyForContinue();
                    locationView.Menu();
                    break;
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            locationView.Menu();
        }
    }


    public int Create(int Id, string StreetAddress, string PostalCode, string City, string StateProvince,
        string CountryId)
    {
        Location location = new Location();
        try
        {
            return location.Insert(Id, StreetAddress, PostalCode, City, StateProvince, CountryId);
        }
        catch (Exception)
        {
            return 0;
        }
    }


    public int GetById()
    {
        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            return 0;
        }
    }


    public List<Location> GetById(int Id)
    {
        Location location = new Location();
        return location.GetById(Id);
    }


    public void Update(int Id, string StreetAddress, string PostalCode, string City, string StateProvince,
        string CountryId, bool isUpdate)
    {
        LocationView locationView = new LocationView();
        try
        {
            int result = this.Update(Id, StreetAddress, PostalCode, City, StateProvince, CountryId);
            
            if (result > 0)
            {
                Message.UpdateSuccess();
                Message.ClickAnyKeyForContinue();
                locationView.Menu();
            }
            else
            {
                Message.UpdateFailed();
                Message.ClickAnyKeyForContinue();
                locationView.Menu();
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            locationView.Menu();
        }
    }


    public int Update(int Id, string StreetAddress, string PostalCode, string City, string StateProvince,
        string CountryId)
    {
        Location location = new Location();
        return location.Update(Id, StreetAddress, PostalCode, City, StateProvince, CountryId);
    }


    public int Delete()
    {
        Location location = new Location();
        try
        {
            return location.Delete(Convert.ToInt32(Console.ReadLine()));
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
