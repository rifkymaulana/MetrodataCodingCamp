using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


public class CountryController
{
    public void Menu()
    {
        CrudView crudView = new CrudView();
        CountryView countryView = new CountryView();
        Country country = new Country();
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    countryView.Create();
                    break;
                case 2:
                    countryView.GetAll(country.GetAll());
                    break;
                case 3:
                    countryView.GetById();
                    break;
                case 4:
                    countryView.Update();
                    break;
                case 5:
                    countryView.Delete();
                    break;
                case 9:
                    crudView.Menu();
                    break;
                default:
                    Message.InputOnlyMenu();
                    Message.ClickAnyKeyForContinue();
                    countryView.Menu();
                    break;
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            countryView.Menu();
        }
    }


    public int Create(string Id, string Name, int RegionId)
    {
        Country country = new Country();
        try
        {
            return country.Insert(Id, Name, RegionId);
        }
        catch (Exception)
        {
            return 0;
        }
    }


    public string GetById()
    {
        try
        {
            return Console.ReadLine();
        }
        catch (Exception)
        {
            return "";
        }
    }


    public List<Country> GetById(string Id)
    {
        Country country = new Country();
        return country.GetById(Id);
    }


    public void Update(string Id, string Name, int RegionId, bool isUpdate)
    {
        CountryView countryView = new CountryView();
        try
        {
            int result = this.Update(Id, Name, RegionId);
            if (result > 0)
            {
                Message.UpdateSuccess();
                Message.ClickAnyKeyForContinue();
                countryView.Menu();
            }
            else
            {
                Message.UpdateFailed();
                Message.ClickAnyKeyForContinue();
                countryView.Menu();
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            countryView.Menu();
        }
    }


    public int Update(string Id, string Name, int RegionId)
    {
        Country country = new Country();
        try
        {
            return country.Update(Id, Name, RegionId);
        }
        catch (Exception)
        {
            return 0;
        }
    }


    public int Delete()
    {
        Country country = new Country();
        try
        {
            return country.Delete(Console.ReadLine());
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
