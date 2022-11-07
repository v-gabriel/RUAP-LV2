using ContactManager.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace ContactManager.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";
        private readonly HttpContext ctx;

        public ContactRepository(IHttpContextAccessor httpContextAccessor)
        {
            this.ctx = httpContextAccessor.HttpContext;

            if (ctx != null)
            {
                if (MemoryCache.Default[CacheKey] == null)
                {
                    var contacts = new Contact[]
                    {
                        new Contact()
                        {
                            Id = 1, Name = "Initial 1"
                        },
                        new Contact
                        {
                            Id = 2, Name = "Initial 2"
                        }
                    };

                    MemoryCache.Default[CacheKey] = contacts;
                }
            }
        }

        public Contact[] GetAllContacts()
        {
            if (ctx != null)
            {
                var res = (Contact[])MemoryCache.Default[CacheKey];
                return res;
            }

            return new Contact[]
            {
                new Contact
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
        }

        public Contact[] SaveContact(Contact contact)
        {
            if (ctx != null)
            {
                try
                {
                    var list = new List<Contact>();
                    var currentData = (Contact[])MemoryCache.Default[CacheKey];
                    foreach (var data in currentData)
                    {
                        list.Add(data);
                    }
                    list.Add(contact);
                    MemoryCache.Default[CacheKey] = list.ToArray();

                    return (Contact[])MemoryCache.Default[CacheKey];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }

            return null;

        }
    }
}
