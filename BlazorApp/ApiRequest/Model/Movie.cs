namespace BlazorApp.ApiRequest.Model;

public class MovieDataShort
{
    public int MovieID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ImageUrl { get; set; }
    public int Rating { get; set; }
}

public class MovieData
{
    public MovieDataContainer data {get; set;}
    public bool status { get; set; }
}

public class MovieDataContainer
{
    public List<MovieDataShort> movies { get; set; }
}