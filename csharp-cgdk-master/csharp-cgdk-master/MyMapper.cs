using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Com.CodeGame.CodeWizards2016.DevKit.CSharpCgdk.Model;

namespace Com.CodeGame.CodeWizards2016.DevKit.CSharpCgdk
{
    class MyMap
    {
        

        public enum PointType { Tree, Wizard, Tower, Base, Allies, Enemy, Waypoint, TopLane, MiddleLane, BottomLane, Unknown, MapCorner, HalfWay, MapCenter, Bonuses}
        
        public MyMap(Wizard self, World world, Game game)
        { 
            this.self = self;
            this.world = world;
            this.game = game;
            Initialize();
        }

        public void Initialize()
        {
           this.waypoints = new PointList();
           this.buildings = new PointList();
           this.trees = new PointList();
           InitBaseWaypoints();
        }

        private void InitBaseWaypoints()
        {
            //Точка своей базы
            MapPoint basePoint = GetBasePoint();
            waypoints.Add(basePoint); 

            //Точка зеркальная от своей базы (правый верхний угол) - ближайшая к чужой базе
            MapPoint myPoint = new MapPoint(basePoint.Y, basePoint.X, PointType.Base);
            myPoint.AddPointType(PointType.Enemy);
            myPoint.AddPointType(PointType.BottomLane);
            myPoint.AddPointType(PointType.TopLane);
            myPoint.AddPointType(PointType.MiddleLane);
            myPoint.AddPointType(PointType.Unknown);
            waypoints.Add(myPoint);

            //Центральная точка
            myPoint = new MapPoint(game.MapSize / 2, game.MapSize / 2, PointType.MapCenter);                        
            myPoint.AddPointType(PointType.MiddleLane);
            myPoint.AddPointType(PointType.Unknown);
            waypoints.Add(myPoint);

            //Левый верхний угол
            myPoint = new MapPoint(basePoint.X, basePoint.X, PointType.MapCorner);
            myPoint.AddPointType(PointType.TopLane);
            myPoint.AddPointType(PointType.Unknown);
            waypoints.Add(myPoint);

            //Правый нижний угол
            myPoint = new MapPoint(basePoint.Y, basePoint.Y, PointType.MapCorner);
            myPoint.AddPointType(PointType.BottomLane);
            myPoint.AddPointType(PointType.Unknown);
            waypoints.Add(myPoint);

            //Промежуточные точки на косых тропах идущих от центра
                // Точка между базой и центром
            myPoint = new MapPoint((basePoint.X + game.MapSize / 2) / 2, (basePoint.Y + game.MapSize / 2) / 2, PointType.MiddleLane);
            myPoint.AddPointType(PointType.HalfWay);
            myPoint.AddPointType(PointType.Unknown);
            waypoints.Add(myPoint);

              // Точка между базой противника и центром
            myPoint = new MapPoint((basePoint.Y + game.MapSize / 2) / 2, (basePoint.X + game.MapSize / 2) / 2, PointType.MiddleLane);
            myPoint.AddPointType(PointType.HalfWay);
            myPoint.AddPointType(PointType.Unknown);
            waypoints.Add(myPoint);

               // Точка между центром и правым нижним углом
            myPoint = new MapPoint((basePoint.Y + game.MapSize / 2) / 2, (basePoint.Y + game.MapSize / 2) / 2, PointType.HalfWay);            
            myPoint.AddPointType(PointType.Unknown);
            waypoints.Add(myPoint);

               // Точка между центром и левым верхним углом
            myPoint = new MapPoint((basePoint.X + game.MapSize / 2) / 2, (basePoint.X + game.MapSize / 2) / 2, PointType.HalfWay);
            myPoint.AddPointType(PointType.Unknown);
            waypoints.Add(myPoint);
            
        }

        private MapPoint GetBasePoint()
        {
            for (int i = 0; i < this.world.Buildings.Count(); i++)
                if ((this.world.Buildings[i].Faction == self.Faction ) && (this.world.Buildings[i].Type == BuildingType.FactionBase))
                        return new MapPoint(this.world.Buildings[i].X, this.world.Buildings[i].Y, PointType.Base);

            MapPoint basePoint = new MapPoint(0, game.MapSize, PointType.Base);
            basePoint.AddPointType(PointType.Allies);
            basePoint.AddPointType(PointType.BottomLane);
            basePoint.AddPointType(PointType.TopLane);
            basePoint.AddPointType(PointType.MiddleLane);

            return basePoint;
        }

        private Wizard self;
        private  World world;
        private  Game game;

        private PointList waypoints;
        private PointList buildings;
        private PointList trees;
    }

    class PointList : List<MapPoint>
    {
        public PointList()
        {
        
        }

        public void AddPoint(double x, double y, MyMap.PointType ptype)
        {
             this.Add(new MapPoint(x,y,ptype));
        }
    }

    class MapPoint
    {

        public MapPoint()
        {
        }

        public MapPoint(double x, double y, MyMap.PointType pointType)
      {
          this.pointType.Add(pointType);
          this.x = x;
          this.y = y;
      }

        public void AddPointType(MyMap.PointType pointType)
        {
            this.pointType.Add(pointType);
        }

        private double x;
        private double y;
        private List<MyMap.PointType> pointType;
        public MyMap.PointType PointType => pointType.First();
        public List<MyMap.PointType> PointTypeStack => pointType;
        public double X => x;
        public double Y => y;


    }
}
