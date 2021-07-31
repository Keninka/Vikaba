using System;
using System.Collections.Generic;
using System.Linq;

namespace Vikaba.Data.Database
{
    public class NewsDB
    {
        public static readonly List<News> NewsList =
            Enumerable.Range(0, 10).Select(newsId => new News
                {
                    Id = newsId,

                    PublishedAt = Faker.Identification.DateOfBirth(),

                    CreatedAt = Faker.Identification.DateOfBirth(),

                    Headline = Faker.Lorem.Sentence(8),

                    SubHeadline = Faker.Lorem.Sentence(8),

                    Content = string.Join(' ', Faker.Lorem.Paragraphs(4)),

                    Tags = Faker.Lorem.Words(8)
                        .Select((word, tagId) => new Tag
                        {
                            Id = tagId,
                            Title = word,
                        }).ToList()
                })
                .ToList();
    }
}