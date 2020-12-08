// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "FishingSpot", columnHash: 0xbbebac3f )]
    public class FishingSpot : IExcelRow
    {
        
        public byte GatheringLevel;
        public SeString BigFishOnReach;
        public SeString BigFishOnEnd;
        public byte FishingSpotCategory;
        public bool Rare;
        public LazyRow< TerritoryType > TerritoryType;
        public LazyRow< PlaceName > PlaceNameMain;
        public LazyRow< PlaceName > PlaceNameSub;
        public short X;
        public short Z;
        public ushort Radius;
        public byte Unknown11;
        public LazyRow< Item >[] Item;
        public LazyRow< PlaceName > PlaceName;
        public byte Order;
        
        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina, Language language )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            GatheringLevel = parser.ReadColumn< byte >( 0 );
            BigFishOnReach = parser.ReadColumn< SeString >( 1 );
            BigFishOnEnd = parser.ReadColumn< SeString >( 2 );
            FishingSpotCategory = parser.ReadColumn< byte >( 3 );
            Rare = parser.ReadColumn< bool >( 4 );
            TerritoryType = new LazyRow< TerritoryType >( lumina, parser.ReadColumn< ushort >( 5 ), language );
            PlaceNameMain = new LazyRow< PlaceName >( lumina, parser.ReadColumn< ushort >( 6 ), language );
            PlaceNameSub = new LazyRow< PlaceName >( lumina, parser.ReadColumn< ushort >( 7 ), language );
            X = parser.ReadColumn< short >( 8 );
            Z = parser.ReadColumn< short >( 9 );
            Radius = parser.ReadColumn< ushort >( 10 );
            Unknown11 = parser.ReadColumn< byte >( 11 );
            Item = new LazyRow< Item >[ 10 ];
            for( var i = 0; i < 10; i++ )
                Item[ i ] = new LazyRow< Item >( lumina, parser.ReadColumn< int >( 12 + i ), language );
            PlaceName = new LazyRow< PlaceName >( lumina, parser.ReadColumn< ushort >( 22 ), language );
            Order = parser.ReadColumn< byte >( 23 );
        }
    }
}