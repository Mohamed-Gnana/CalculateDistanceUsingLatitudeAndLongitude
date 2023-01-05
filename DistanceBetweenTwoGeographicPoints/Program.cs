using System.Device.Location;

const double PIx = 3.141592653589793;

var events = new List<(double lat, double lon, string city)>()
{
    (30.79, 31, "Tanta"), // Tanta -- 84 KM Straight Line
    (30.128611, 31.242222, "Shubra"), // Shubra -- 9KM
    (29.952654, 30.921919, "6th Octobor"), // 6 October 33.62KM
    (31.037933, 31.381523, "Mansoura"), // Mansoura 108.77KM
    (31.205753, 29.924526, "Alexandria"), // Alex 178.07KM
    (25.687243, 32.639637, "Luxor"), // Luxor 504.37KM
    (31.354343, 27.237316, "Matruh") // Matruh 409.42KM
};

double RADIUS = 6378.16;

// customer in cairo
double cairoLon = 31.24967;
double cairoLat = 30.06263;

foreach(var point in events)
{
    var point1 = new GeoCoordinate(cairoLat, cairoLon);
    var point2 = new GeoCoordinate(point.lat, point.lon);

    if(point1.GetDistanceTo(point2) / 1000 < 100)
        Console.WriteLine(point.city);


    double dlon = Radians(cairoLon - point.lon);
    double dlat = Radians(cairoLat - point.lat);

    double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(point.lat)) * Math.Cos(Radians(cairoLat)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
    double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
    Console.WriteLine(angle * RADIUS);
}

static double Radians(double x)
{
    return x * PIx / 180;
}