namespace API.Services.PositionSync;

internal static class Extensions
{
    internal static void AddHeaders(this HttpRequestMessage request)
    {
        request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:121.0) Gecko/20100101 Firefox/121.0");
        request.Headers.Add("Accept", "application/json, text/plain, */*");
        request.Headers.Add("Accept-Language", "de,en-US;q=0.7,en;q=0.3");
        request.Headers.Add("Referer", "https://www.zivildienst.gv.at/zivildienst-stellen/platzangebot.html");
        request.Headers.Add("Connection", "keep-alive");
        request.Headers.Add("Cookie", "JSESSIONID=C3F72E7932E379D44AA6773B59543D86; K9=B");
        request.Headers.Add("Sec-Fetch-Dest", "empty");
        request.Headers.Add("Sec-Fetch-Mode", "cors");
        request.Headers.Add("Sec-Fetch-Site", "same-origin");
    }
}