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
        public enum PointType { Tree, Wizard, Tower, Base, Allies, Enemy, Waypoint}
        
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
            MapPoint MyBase = GetBasePoint();
            waypoints.AddPoint(100.0,0,PointType.Waypoint);
            waypoints.AddPoint(0,0,PointType.Waypoint);
            waypoints.AddPoint(0,0,PointType.Waypoint);
            waypoints.AddPoint(0,0,PointType.Waypoint);
            waypoints.AddPoint(0,0,PointType.Waypoint);
        }

        private MapPoint GetBasePoint()
        {
            for (int i = 0; i < this.world.Buildings.Count(); i++)
            {
                if (this.world.Buildings[i].Faction == self.Faction) && (this.world.Buildings[i].Type=BuildingType.FactionBase)
                {
                    return new MapPoint(this.world.Buildings[i].X,this.world.Buildings[i].Y, PointType.Base)
                }
            }

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

        public void AddPoint(int x, int y, MyMap.PointType ptype)
        {
             this.Add(new MapPoint(x,y,ptype));
        }
    }

    class MapPoint
    {

        public MapPoint()
        {
        }

        public MapPoint(int x, int y, MyMap.PointType pType)
      {
          this.pType = pType;
          this.x = x;
          this.y = y;
      }

        private int x;
        private int y;
        private MyMap.PointType pType;
        public MyMap.PointType pointType => pType;


    }
}
