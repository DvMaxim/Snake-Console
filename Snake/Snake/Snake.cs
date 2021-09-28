using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Snake : Figure 
	{
		Direction direction;
		Direction old_direction;

		public Snake( Point tail, int length, Direction _direction )
		{
			direction = _direction;
			old_direction = direction;
			pList = new List<Point>();
			for ( int i = 0; i < length; i++ )
			{
				Point p = new Point( tail );
				pList.Add(p);
				p.Move(i, direction);
			}
		}

		public void Move()
		{
            if (direction != old_direction)
            {
                if (old_direction == Direction.LEFT)
                {
                    if (direction == Direction.RIGHT)
                    {
						direction = old_direction;
                    }
                }
                else if (old_direction == Direction.RIGHT)
                {
                    if (direction == Direction.LEFT)
                    {
						direction = old_direction;
					}
                }
                else if (old_direction == Direction.UP)
                {
                    if (direction == Direction.DOWN)
                    {
						direction = old_direction;
					}
                }
                else if (old_direction == Direction.DOWN)
                {
                    if (direction == Direction.UP)
                    {
						direction = old_direction;
					}
                }
            }
            Point tail = pList.First();			
			Point head = GetNextPoint();
			pList.Add( head );
			head.drawGreenPoint();
			pList.Remove(tail);
			tail.Clear();
		}

		public void setEqualDirections()
        {
			old_direction = direction;
		}

		public Point GetNextPoint()
		{
			Point head;
			if (pList.Count == 1)
            {
				head = pList.First();
			}
            else
            {
				head = pList.Last();
			}
			Point nextPoint = new Point(head);
			nextPoint.Move(1, direction);
			return nextPoint;
		}

		internal bool IsHitTail()
		{
			Point head = pList.Last();
			for(int i = 0; i < pList.Count - 1; i++ )
			{
				if ( head.IsHit( pList[i] ) )
					return true;
			}
			return false;
		}

		public void HandleKey(ConsoleKey key)
		{
			old_direction = direction;
			if ( key == ConsoleKey.LeftArrow )
				direction = Direction.LEFT;
			else if ( key == ConsoleKey.RightArrow )
				direction = Direction.RIGHT;
			else if ( key == ConsoleKey.DownArrow )
				direction = Direction.DOWN;
			else if ( key == ConsoleKey.UpArrow )
				direction = Direction.UP;
		}

		public bool Eat( Point food )
		{
			Point after_head = GetNextPoint();
			if ( after_head.IsHit( food ) )
			{
				food.sym = after_head.sym;
				food.drawGreenPoint();
				pList.Add( food );
				return true;
			}
			else
            {
				return false;
			}
		}

        public override void Draw()
        {
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			base.Draw();
			Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
