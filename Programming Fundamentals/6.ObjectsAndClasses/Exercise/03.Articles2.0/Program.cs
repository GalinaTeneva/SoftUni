using System;
using System.Collections.Generic;

namespace _03.Articles2._0
{
    class Program
    {
        class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }

            public string Author { get; set; }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }

        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int currArticle = 1; currArticle <= articlesCount; currArticle++)
            {
                string[] currArticleInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string currTitle = currArticleInfo[0];
                string currContent = currArticleInfo[1];
                string currAuthor = currArticleInfo[2];

                Article article = new Article(currTitle, currContent, currAuthor);
                articles.Add(article);
            }

            string line = Console.ReadLine();

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }

        }
    }
}
