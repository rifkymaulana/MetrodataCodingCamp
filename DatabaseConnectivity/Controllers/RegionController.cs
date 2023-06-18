using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


class RegionController
{
    public void Menu()
    {
        CrudView crudView = new CrudView();
        RegionView regionView = new RegionView();
        Region region = new Region();
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    regionView.Create();
                    break;
                case 2:
                    regionView.GetAll(region.GetAll());
                    break;
                case 3:
                    regionView.GetById();
                    break;
                case 4:
                    regionView.Update();
                    break;
                case 5:
                    regionView.Delete();
                    break;
                case 9:
                    crudView.Menu();
                    break;
                default:
                    Message.InputOnlyMenu();
                    Message.ClickAnyKeyForContinue();
                    regionView.Menu();
                    break;
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            regionView.Menu();
        }
    }


    public int Create(string Name)
    {
        Region region = new Region();
        try
        {
            return region.Insert(Name);
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


    public List<Region> GetById(int Id)
    {
        Region region = new Region();
        return region.GetById(Id);
    }


    public void Update(int Id)
    {
        RegionView regionView = new RegionView();
        try
        {
            string Name = Console.ReadLine();
            int result = this.Update(Id, Name);
            if (result > 0)
            {
                Message.UpdateSuccess();
                Message.ClickAnyKeyForContinue();
                regionView.Menu();
            }
            else
            {
                Message.UpdateFailed();
                Message.ClickAnyKeyForContinue();
                regionView.Menu();
            }
        }
        catch (Exception)
        {
            Message.InputOnlyNumber();
            Message.ClickAnyKeyForContinue();
            regionView.Menu();
        }
    }


    public int Update(int Id, string Name)
    {
        Region region = new Region();
        try
        {
            return region.Update(Id, Name);
        }
        catch (Exception)
        {
            return 0;
        }
    }


    public int Delete()
    {
        Region region = new Region();
        try
        {
            return region.Delete(Convert.ToInt32(Console.ReadLine()));
        }
        catch (Exception)
        {
            return 0;
        }
    }


}
