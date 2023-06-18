using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers;


class RegionController
{
    public void Menu()
    {
        RegionView regionView = new RegionView();
        Region region = new Region();
        try
        {
            int inputMenu = Convert.ToInt32(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    break;
                case 2:
                    regionView.GetAll(region.GetAll());
                    break;
                case 3:
                    regionView.GetById();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 9:
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

}
