public class Main
{
	public static Simulation simulator;

	static
	{
		simulator = new Simulation();
	} // end static

	public static void main(String[] args)
	{
		simulator.initialize();
	} // end method main
} // end class Main
