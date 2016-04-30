namespace RYAP.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;
    using System.Xml.Linq;
    using System.Linq;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<Entities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Entities context)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();

            var doc = XDocument.Parse(Properties.Resources.Data);

            var root = doc.Element("data");

            var authors = from j in root.Element("authors").Elements("author")
                          select new Author
                          {
                              Email = j.Element("email").Value,
                              Name = j.Element("name").Value,
                              Location = string.Format("{0}, {1}, {2}",
                                j.Element("city").Value,
                                j.Element("zipCode").Value,
                                j.Element("country").Value),
                              Status = AuthorStatus.CanPost
                          };

            context.Authors.AddOrUpdate(a => a.Email, authors.ToArray());

            context.SaveChanges();

            var q = from j in root.Element("jokes").Elements("joke")
                    select new
                    {
                        Email = j.Element("email").Value,
                        Question = j.Element("question").Value,
                        Answer = j.Element("answer").Value,
                        AddedOn = (DateTime)j.Element("addedOn")
                    };

            foreach (var data in q)
            {
                var joke = context.Jokes.FirstOrDefault(j =>
                    j.Author.Email == data.Email && j.Question == data.Question);

                if (joke == null)
                    context.Jokes.Add(joke = new Joke());

                joke.AddedOn = data.AddedOn;
                joke.UpdatedOn = DateTime.UtcNow;
                joke.Answer = data.Answer;
                joke.AuthorId = context.Authors.First(a => a.Email == data.Email).Id;
                joke.Question = data.Question;
                joke.Status = JokeStatus.Approved;
                joke.UpdatedOn = DateTime.UtcNow;

                context.SaveChanges();
            }
        }
    }
}
