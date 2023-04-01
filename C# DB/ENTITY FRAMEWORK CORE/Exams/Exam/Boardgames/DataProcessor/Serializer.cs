namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            ExportCreatorDto[] creatorDtos = context.Creators
                .Where(c => c.Boardgames.Count > 0)
                .Select(c => new ExportCreatorDto()
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = string.Concat(c.FirstName, " ", c.LastName),
                    boardgameDtos = c.Boardgames
                        .Select(b => new ExportCreatorBoardgameDto()
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished
                        })
                        .OrderBy(b => b.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Creators");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCreatorDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder(); 
            StringWriter writer = new StringWriter(sb);

            xmlSerializer.Serialize(writer, creatorDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellersWithBoardgames = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    /*Name = */s.Name,
                    /*Website = */s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                        .Select(bs => new
                        {
                            /*Name = */bs.Boardgame.Name,
                            /*Rating = */bs.Boardgame.Rating,
                            /*Mechanics = */bs.Boardgame.Mechanics,
                            Category = bs.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(bs => bs.Rating)
                        .ThenBy(bs => bs.Name)
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellersWithBoardgames, Formatting.Indented);
        }
    }
}