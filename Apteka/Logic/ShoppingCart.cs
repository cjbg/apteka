using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apteka.Models;
using System.Web.Mvc;

namespace Apteka.Logic
{
    public partial class ShoppingCart
    {
        db_lekiContext storeDB = new db_lekiContext();

        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(t_produkty producty)
        {
            // Get the matching cart and album instances
            var cartItem = storeDB.t_CartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProduktId == producty.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new t_CartItems
                {
                    ProduktId = producty.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.t_CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Count++;
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.t_CartItems.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.t_CartItems.Remove(cartItem);
                }
                // Save changes
                storeDB.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = storeDB.t_CartItems.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.t_CartItems.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public List<t_CartItems> GetCartItems()
        {
            return storeDB.t_CartItems.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.t_CartItems
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in storeDB.t_CartItems
                              where cartItems.CartId == ShoppingCartId
                              && cartItems.ProduktId == cartItems.t_produkty.Id
                              select (int?)cartItems.Count *
                              cartItems.t_produkty.cena).Sum();

            return total ?? decimal.Zero;
        }
        //ToDo: zrobic dobry Order bo ten nie dziala (XML i takie tam)
        public int CreateOrder(t_zamowienia order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new t_zamowienia
                {
                    /*
                    AlbumId = item.AlbumId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Album.Price,
                    Quantity = item.Count
                     * */
                };
                // Set the order total of the shopping cart
                /*
                orderTotal += (item.Count * item.Album.Price);
                 * */

                storeDB.t_zamowienia.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            //order.Total = orderTotal;

            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.Id;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.t_CartItems.Where(
                c => c.CartId == ShoppingCartId);

            foreach (t_CartItems item in shoppingCart)
            {
                item.CartId = userName;
            }
            storeDB.SaveChanges();
        }
    }
}