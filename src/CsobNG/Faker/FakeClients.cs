using Model;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System;
using Bogus;

namespace Faker
{
    public class FakeClients
    {
        public static List<Client> GetClients(int cnt)
        {
            List<Client> list = new List<Client>();
            var faker = new Bogus.Faker("cz");

            var gender = faker.PickRandom<Bogus.DataSets.Name.Gender>();
            for (int i = 0; i < cnt; i++)
            {
                var firstName = faker.Name.FirstName(gender);
                var lastName = faker.Name.LastName(gender);
                var p = new Client()
                {
                    Id = 0,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = faker.Internet.Email(firstName, lastName),

                };

                list.Add(p);
            }

            return list;
        }
    }
}