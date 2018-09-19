using System.Collections.Generic;

using GiftApi.Models;

namespace GiftApi.Infrastructure
{
    public interface IGiftRepository
    {
        IEnumerable<Gift> Gifts { get; }
    }

    public class MemoryGiftRepository : IGiftRepository
    {
        private readonly Dictionary<string, Gift> _items;

        public MemoryGiftRepository()
        {
            _items = new Dictionary<string, Gift>
            {
                {
                    "amazon", new Gift
                    {
                        Id = "amazon", Name = "Amazon.co.uk Gift Card",
                        Description =
                            "Amazon.co.uk Gift Cards can be redeemed towards millions of items at www.amazon.co.uk. Amazon.co.uk’s huge selection includes products in Books, Electronics, Music, MP3 Downloads, Film & TV, Clothing, Video Games, Software, Sports & Outdoors, Toys, Baby, Computers & Office, Home & Garden, Jewellery, Beauty, DIY & Home Improvement, Office Products, Camera & Photo, Pet Supplies, and more. Amazon.co.uk is the place to find and discover almost anything you want to buy online at a great price."
                    }
                },
                {
                    "currys-pc-world", new Gift
                    {
                        Id = "currys-pc-world", Name = "Currys PC World Gift Card",
                        Description =
                            "To stay on the ball with modern technology, Currys PC World is all you need! With appliances big and small, for the home and to take with you on your daily adventures, treat someone to a Currys gift card and you’ll be putting them in touch with the new age! Always wowing the public with its grand array of laptops and desktops, now you can go further with your hobby or work when you tune in to innovative notebook designs, tablets and more. With a PC World gift card, your family member or friend could make a real investment. For the home - shop sturdy kitchen goods like fridge freezers, or small appliances such as toasters, kettles and more too - Currys PC World really has a fully stacked catalogue. Proudly presenting the best in entertainment products as well - find outstanding TV sets, gaming goods, audio equipment and more - everyone can find their joy at Currys PC World."
                    }
                }
            };
        }

        public IEnumerable<Gift> Gifts => _items.Values;
    }
}
