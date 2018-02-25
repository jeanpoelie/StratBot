// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineChartModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the LineChartModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Stratbot
{
	/// <summary>
	/// The line chart model.
	/// </summary>
	public class MapModel
    {
		/// <summary>
		/// Gets or sets the id of the map.
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the map
		/// </summary>
		public string Name { get; set; }

        public string GameName { get; set; }

	    public string ImageUrl { get; set; }
    }
}