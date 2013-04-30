using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apteka.Models;


namespace Apteka.Common
{
    public class MenuItems
    {
        public static bool logedUser = false;
        public static bool logedUserShop = false;

        public static List<SimpleVerticalMenuModel> Get()
        {
            var menuItems = new List<SimpleVerticalMenuModel>();

            var simpleLoad = new SimpleVerticalMenuModel { Text = "Wyszukaj według typu leku" };
            simpleLoad.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "Index", Controller = "Category", Text = "Wszystkie leki"},
                                              new MenuItemModel{Action = "Kosmetyki", Controller = "Category", Text = "Kosmetyki"},
                                              new MenuItemModel{Action = "Dieta", Controller = "Category", Text = "Dieta"},                                              
                                              new MenuItemModel{Action = "Dezynfekcyjny", Controller = "Category", Text = "Dezynfekcyjne"},
                                              new MenuItemModel{Action = "Homeopatyczny", Controller = "Category", Text = "Homeopatyczne"},
                                              new MenuItemModel{Action = "Doping", Controller = "Category", Text = "Środek dopingujący"}
                                          };

            var inlineEdit = new SimpleVerticalMenuModel { Text = "Wyszykaj lek po" };
            inlineEdit.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "Producent", Controller = "Category", Text = "producencie"},
                                              new MenuItemModel{Action = "Internaz", Controller = "Category", Text = "nazwie międzynarodowej"},
                                              new MenuItemModel{Action = "Apteka", Controller = "Category", Text = "aptece"}
                                          };
            menuItems.Add(simpleLoad);
            menuItems.Add(inlineEdit);

            if (logedUser == true)
            {
                var formEdit = new SimpleVerticalMenuModel { Text = "Twoje konto" };
                formEdit.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "ChangePassword", Controller = "Account", Text = "Zmień hasło"},
                                              new MenuItemModel{Action = "EdycjaDanych", Controller = "Account", Text = "Edytuj twoje dane"}                                              
                                          };
                if(logedUserShop == true)
                {
                    MenuItemModel asd = new MenuItemModel{Action = "EdycjaDanychSklepu", Controller = "Account", Text = "Edytuj dane sklepu"};
                    formEdit.MenuItems.Add(asd);                  
                }
                menuItems.Add(formEdit);
            }
            /*var formEdit1 = new SimpleVerticalMenuModel { Text = "90's Bands" };
            formEdit1.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "Radiohead", Controller = "List90Bands", Text = "Radiohead"},
                                              new MenuItemModel{Action = "PearlJam", Controller = "List90Bands", Text = "Pearl Jam"},
                                              new MenuItemModel{Action = "RedHotChiliPeppers", Controller = "List90Bands", Text = "Red Hot Chili Peppers"}
                                          };
            var formEdit2 = new SimpleVerticalMenuModel { Text = "90's Bands" };
            formEdit2.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "Radiohead", Controller = "List90Bands", Text = "Radiohead"},
                                              new MenuItemModel{Action = "PearlJam", Controller = "List90Bands", Text = "Pearl Jam"},
                                              new MenuItemModel{Action = "RedHotChiliPeppers", Controller = "List90Bands", Text = "Red Hot Chili Peppers"}
                                          };*/
                                        
            
            //menuItems.Add(formEdit1);
            //menuItems.Add(formEdit2);
            return menuItems;
        }
    }
}