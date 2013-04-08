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

            var simpleLoad = new SimpleVerticalMenuModel { Text = "70's Bands" };
            simpleLoad.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "LedZeppelin", Controller = "List70Bands", Text = "Led Zeppelin"},
                                              new MenuItemModel{Action = "Index", Controller = "Home", Text = "The Who"},
                                              new MenuItemModel{Action = "PinkFloyd", Controller = "List70Bands", Text = "Pink Floyd"},
                                              new MenuItemModel{Action = "LynyrdSkynyrd", Controller = "List70Bands", Text = "Lynyrd Skynyrd"}
                                          };

            var inlineEdit = new SimpleVerticalMenuModel { Text = "80's Bands" };
            inlineEdit.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "U2", Controller = "List80Bands", Text = "U2"},
                                              new MenuItemModel{Action = "GunsNRoses", Controller = "List80Bands", Text = "Guns N' Roses"},
                                              new MenuItemModel{Action = "Metallica", Controller = "List80Bands", Text = "Metallica"},
                                              new MenuItemModel{Action = "IronMaidens", Controller = "List80Bands", Text = "Iron Maidens"},
                                              new MenuItemModel{Action = "TheCure", Controller = "List80Bands", Text = "The Cure"}
                                          };
            var formEdit = new SimpleVerticalMenuModel { Text = "90's Bands" };
            formEdit.MenuItems = new List<MenuItemModel>
                                          {
                                              new MenuItemModel{Action = "Radiohead", Controller = "List90Bands", Text = "Radiohead"},
                                              new MenuItemModel{Action = "PearlJam", Controller = "List90Bands", Text = "Pearl Jam"},
                                              new MenuItemModel{Action = "RedHotChiliPeppers", Controller = "List90Bands", Text = "Red Hot Chili Peppers"}
                                          };
            menuItems.Add(simpleLoad);
            menuItems.Add(inlineEdit);
            menuItems.Add(formEdit);
            return menuItems;
        }
    }
}