// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineChartModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the LineChartModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using Newtonsoft.Json;

namespace Stratbot
{
	/// <summary>
	/// The line chart model.
	/// </summary>
	public class LoadoutModel
	{
	    [JsonProperty("Id")]
	    public int? Id { get; set; }

	    [JsonProperty("Name")]
	    public string Name { get; set; }

	    [JsonProperty("Type")]
	    public string Type { get; set; }
    }
}