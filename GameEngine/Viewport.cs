using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;
using SFML.System;

namespace GameEngine
{
    public struct ScreenLocation
    {
        public int X;
        public int Y;
    }

    public class Viewport : IDisposable
    {
        private GameObject _gameObject;
        private int _tileHeight = 0;
        private int _tileWidth = 0;
        private int _screenWidth = 0;
        private int _screenHeight = 0;
        private int _scrollSpeed = 0;
        private int _screenTilesPerColumn;   
        private int _screenTilesPerRow;      
        private Level _level;
        private int originXtile = 0; 
        public int xOffset = 0;     
        private int originYtile = 0; 
        public int yOffset = 0;     
        public List<Entity> BackSprites = new List<Entity>();

        Sprite spBack = new Sprite();

        public bool IsEndOfLevel
        {
            get 
            {
                return (_screenTilesPerColumn + originYtile >= _level.GetTileColumns-1);
            }

        }

        public bool IsStartOfLevel
        {
            get
            {
                return(originYtile == 0);
            }

        }
        public int TileHeight
        {
            get { return _tileHeight; }
        }

        public Viewport(GameObject gameObject, int tileHeight, int tileWidth, Level level)
        {
            _gameObject = gameObject;
            _screenHeight = (int)gameObject.Window.Size.X;
            _screenWidth = (int)gameObject.Window.Size.Y;
            _tileHeight = tileHeight;
            _tileWidth = tileWidth;
            _level = level;

            _screenTilesPerRow = _screenWidth / _tileWidth;
            _screenTilesPerColumn = _screenHeight / _tileHeight;
        }

        public bool Scroll (Direction d, int Speed)
        {
            _scrollSpeed = Speed;
            return Scroll(d);
        }

        public bool Scroll(Direction d)
        {
            if (d == Direction.RIGHT)
            {
                if (!IsEndOfLevel)
                {
                    yOffset = yOffset - _scrollSpeed;

                    if (yOffset <= -_tileWidth)
                    {
                        yOffset = 0;
                        originYtile++;
                    }

                    return true;
                }
                else
                    return false;
            }

            if (d == Direction.LEFT)
            {
                if (!IsStartOfLevel)
                {
                    yOffset = yOffset - _scrollSpeed;

                    if (yOffset > _tileWidth)
                    {
                        yOffset = 0;
                        originYtile--;
                    }

                    return true;
                }
                else
                    return false;
            }

            return false;
        }

        public List<Entity> Render()
        {
            List<Entity> newEntities = new List<Entity>();

            BackSprites.Clear();

            int screenX = 0;
            int screenY = -1;

            for (int x = originXtile; x < _screenTilesPerRow + originXtile; x++)
            {
                for (int y = originYtile; y < _screenTilesPerColumn + originYtile + 2; y++)
                {
                    if (!_level.Tiles[x, y].Background)
                    {
                        if (_level.Tiles[x, y].Entity != "")
                        {
                            string entityName = _level.Tiles[x, y].Entity;
                            if (_level.Tiles[x, y].Static != true)
                            {
                                Tile t = new Tile();
                                t.Background = true;
                                _level.Tiles[x, y] = t;
                            }

                            ScreenLocation sl = TileToScreen(x, y);
                            Entity e2 = new Entity(this._gameObject);
                            e2.Name = entityName;
                            e2.X = sl.X;
                            e2.Y = sl.Y;
                            e2.OriginTileRow = x;
                            e2.OriginTileCol = y;
                            newEntities.Add(e2);
                        }
                        else
                        { 
                            spBack = new Sprite(ResourceManager.GetInstance().GetTexture(_level.Tiles[x,y].Resource));
                            int x1 = (_tileHeight * screenY) + yOffset;
                            int y1 = (_tileWidth * screenX) + xOffset;
                            spBack.Position = new Vector2f(x1, y1);
                            spBack.Draw(_gameObject.Window, RenderStates.Default);

                        }
                        
                    }
                    screenY++;
                }

                screenY = -1;
                screenX++;
            }

            return newEntities;
        }

        public ScreenLocation TileToScreen(int row, int col)
        {
            ScreenLocation s = new ScreenLocation();

            s.Y = (row * _tileHeight) * (originXtile+1);
            s.X = (col * _tileWidth) - ((originYtile+1) * _tileWidth);  
            return s;
        }

        public void Reset()
        {
            originYtile = 0;
            originXtile = 0;
            xOffset = 0;
            yOffset = 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                spBack.Dispose();
            }
        }

    }
}
