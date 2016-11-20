using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.CodeGame.CodeWizards2016.DevKit.CSharpCgdk.Model;

namespace Com.CodeGame.CodeWizards2016.DevKit.CSharpCgdk
{
    class MyMap
    {
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
            mapsize = game.MapSize;
        }

        private Wizard self;
        private  World world;
        private  Game game;
        private double mapsize;

        private PointList waypoints;
        private PointList buildings;
        private PointList trees;
    }

    class PointList : List<MapPoint>
    {
        public PointList()
        {
        
        }
    }

    class MapPoint
    {
        public enum PointType { Tree, Wizard, Tower, Base, Allies, Enemy, Waypoint}

      public MapPoint(int x, int y, PointType pType)
      {
          this.pType = pType;
          this.x = x;
          this.y = y;
      }

        private int x;
        private int y;
        private PointType pType;
        public PointType pointType => pType;


    }
}
