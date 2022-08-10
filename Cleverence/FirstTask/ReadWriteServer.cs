namespace Cleverence.FirstTask
{
    public static class ReadWriteServer
    {
		public static int GetCount()
		{
			lock (lockObject)
			{
				if (writersCount > 0)
					Monitor.Wait(lockObject);

				readersCount++;
			}

			var result = count;

			lock (lockObject)
			{
				readersCount--;

				if (readersCount == 0)
					Monitor.Pulse(lockObject);
			}

			return result;
		}

		public static void AddToCount(int value)
		{
			lock (lockObject)
			{
				writersCount++;

				if (readersCount > 0)
					Monitor.Wait(lockObject);

				count += value;

				writersCount--;

				if (writersCount == 0)
					Monitor.Pulse(lockObject);
			}
		}

		private static int count;
		private static int readersCount;
		private static int writersCount;
		private static readonly object lockObject = new object();
	}
}
