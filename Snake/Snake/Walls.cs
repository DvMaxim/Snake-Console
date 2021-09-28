using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Walls
	{
		List<Figure> wallList;

		public Walls( int mapWidth, int mapHeight )
		{
			wallList = new List<Figure>();
			// Отрисовка рамочки
			HorizontalLine upLine = new HorizontalLine( 1, mapWidth, 0, '#');
			HorizontalLine downLine = new HorizontalLine( 1, mapWidth, mapHeight, '#');
			VerticalLine leftLine = new VerticalLine( 0, mapHeight, 0, '#');
			VerticalLine rightLine = new VerticalLine( 0, mapHeight, mapWidth, '#');

			wallList.Add( upLine );
			wallList.Add( downLine );
			wallList.Add( leftLine );
			wallList.Add( rightLine );
		}

		internal bool IsHit( Figure figure )
		{
			foreach(var wall in wallList)
			{
				if(wall.IsHit(figure))
				{
					return true;
				}
			}
			return false;
		}

		public void Draw()
		{
			foreach ( var wall in wallList )
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				wall.Draw();
				Console.ForegroundColor = ConsoleColor.Black;
			}
		}
	}
}
