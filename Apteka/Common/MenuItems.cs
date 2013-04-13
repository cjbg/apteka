using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apteka.Models;

namespace Apteka.Common
{
    public class MenuItems
    {
        public static List<SimpleVerticalMenuModel> Get()
        {
            var menuItems = new List<SimpleVerticalMenuModel>();

            var simpleLoad = new SimpleVerticalMenuModel { Text = "Wyszukaj według typu leku" };
            simpleLoad.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "Index", Controller = "Home", Text = "Wszystkie leki"},
                                              new MenuItemModel{Action = "Kosmetyki", Controller = "Home", Text = "Kosmetyki"},
                                              new MenuItemModel{Action = "Dieta", Controller = "Home", Text = "Dieta"}                                              
                                          };

            var inlineEdit = new SimpleVerticalMenuModel { Text = "Wyszykaj lek po" };
            inlineEdit.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "Producent", Controller = "Home", Text = "producencie"},
                                              new MenuItemModel{Action = "Internaz", Controller = "Home", Text = "nazwie międzynarodowej"}
                                          };
            var formEdit = new SimpleVerticalMenuModel { Text = "90's Bands" };
            formEdit.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "Radiohead", Controller = "List90Bands", Text = "Radiohead"},
                                              new MenuItemModel{Action = "PearlJam", Controller = "List90Bands", Text = "Pearl Jam"},
                                              new MenuItemModel{Action = "RedHotChiliPeppers", Controller = "List90Bands", Text = "Red Hot Chili Peppers"}
                                          };
            var formEdit1 = new SimpleVerticalMenuModel { Text = "90's Bands" };
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
                                          };
            menuItems.Add(simpleLoad);
            menuItems.Add(inlineEdit);
            menuItems.Add(formEdit);
            menuItems.Add(formEdit1);
            menuItems.Add(formEdit2);
            return menuItems;
        }
    }
}