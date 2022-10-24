using System;

namespace _02.Articles
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

            public void Edit (string content)
            {
                Content = content;
            }

            public void ChangeAuthor (string author)
            {
                Author = author;
            }

            public void Rename(string title) => Title = title;

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }

        }

        static void Main(string[] args)
        {
            string[] initialArticleInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int commandsCount = int.Parse(Console.ReadLine());

            Article article = new Article(initialArticleInfo[0], initialArticleInfo[1], initialArticleInfo[2]);

            for (int currCommand = 1; currCommand <= commandsCount; currCommand++)
            {
                string[] currCommandTokens = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                if (currCommandTokens[0] == "Edit")
                {
                    article.Edit(currCommandTokens[1]);
                }
                else if (currCommandTokens[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(currCommandTokens[1]);
                }
                else if (currCommandTokens[0] == "Rename")
                {
                    article.Rename(currCommandTokens[1]);
                }
            }

            Console.WriteLine(article);
        }
    }
}
