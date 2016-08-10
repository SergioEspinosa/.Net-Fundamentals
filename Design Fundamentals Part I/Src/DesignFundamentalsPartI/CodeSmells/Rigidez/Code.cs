using System;
using System.Collections.Generic;

namespace CodeSmells.Rigidez
{

    public class PaymentProcessor
    {
        //Rigidez
        //Requerimiento: Trear solo los correos publicos del cliente
        public void Execute(int customerId)
        {
            dynamic repoCustomer = default(object);
            var customer = repoCustomer.GetById(customerId);
            var notification = new CustomerNotification();
            //Code
            notification.Send(customer);
        }
    }

    public class CustomerNotification
    {
        public void Send(Customer customer)
        {
            foreach (var address in customer.Addresses)
            {
             //Code   
            }
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public IList<string> Addresses
        {
            get
            {
                dynamic repoAddress = default(object);
                var addresses = repoAddress.GetByCustomer(Name);

                dynamic repoAddressLegacy = new LegacyRepository();
                var addressesLegacy = repoAddressLegacy.Select(new { FullName = Name, DateTime = DateTime.Now.AddDays(-100) });

                var listAddresses = new List<dynamic> { addresses, addressesLegacy };

                var finalAddressList = new List<string>();
                foreach (var address in listAddresses)
                {
                    if (address.Active == false && Category != null)
                    {
                        if (Category == "Super")
                        {
                            if (address.IsLegacy())
                            {
                                finalAddressList.Add(repoAddress.GetById(address.Id));
                            }
                        }
                        else
                        {
                            finalAddressList.Add(address);
                        }
                    }
                }

                addressesLegacy = repoAddressLegacy.Select(new { FullName = Name, DateTime = DateTime.Now.AddDays(-1) });
                foreach (var address in listAddresses)
                {
                    if (address.Active == false && Category != null)
                    {
                        if (Category == "Admin")
                        {
                            finalAddressList.Add(address);
                        }
                    }
                }

                addressesLegacy = repoAddressLegacy.Select(new { FullName = Name, DateTime = DateTime.Now.AddDays(-5) });
                foreach (var address in listAddresses)
                {
                    if (address.Active == false && Category != null)
                    {
                        if (Category == "General")
                        {
                            finalAddressList.Add(address);
                        }
                    }
                }

                return finalAddressList;
            }
        }
    }

    public class LegacyRepository
    {
        public IList<string> Select(object value)
        {
            dynamic repoAddress = default(object);
            List<string> addresses = new List<string>();
            var crypto = new Cryptography();
            foreach (var item in repoAddress.GetAll(value))
            {
                var address = crypto.Decrypt(item);
                if (address != null)
                {
                    if (!address.StartWith("#"))
                    {
                        addresses.Add(address);
                    }
                }
            }
            return addresses;
        }
    }

    public class Cryptography
    {
        public string Decrypt(dynamic value)
        {
            string address = null;
            foreach (var item in value.ToArray())
            {
                var count = item.Substring(0, 10);
                var x = item.Decrypt();
                address = x.Convert(count);
            }
            return address;
        }
        
    }
}
