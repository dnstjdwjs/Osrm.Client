using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models.Requests
{
    public class MatchRequest : BaseRequest
    {
        protected const string DefaultGeometries = "polyline";
        protected const string DefaultOverview = "simplified";
        protected const string DefaultGaps = "split";

        public MatchRequest()
        {
            Geometries = "polyline6";
            Annotations = new string[0];
            Overview = DefaultOverview;
            Timestamps = new int[0];
            Gaps = DefaultGaps;
        }

        /// <summary>
        /// Return route steps for each route
        /// true, false (default)
        /// </summary>
        public bool Steps { get; set; }

        /// <summary>
        /// Returned route geometry format (influences overview and per step)
        /// polyline (default), geojson
        /// </summary>
        public string Geometries { get; set; }

        /// <summary>
        /// Returns additional metadata for each coordinate along the route geometry.
        /// </summary>
        public string[] Annotations { get; set; }

        /// <summary>
        /// Add overview geometry either full, simplified according to highest zoom level it could be display on, or not at all.
        /// simplified (default), full, false
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// Timestamp of the input location.
        /// simplified (default), full, false
        /// </summary>
        public int[] Timestamps { get; set; }

        /// <summary>
        /// Allows the input track modification to obtain better matching quality for noisy tracks.
        /// </summary>
        public bool Tidy { get; set; }

        /// <summary>
        /// Allows the input track splitting based on huge timestamp gaps between points.
        /// </summary>
        public string Gaps { get; set; }

        public override List<Tuple<string, string>> UrlParams
        {
            get
            {
                var urlParams = new List<Tuple<string, string>>(BaseUrlParams);

                urlParams
                    .AddBoolParameter("steps", Steps, false)
                    .AddStringParameter("geometries", Geometries, () => Geometries != DefaultGeometries)
                    .AddStringParameter("annotations", string.Join(",", Annotations), () => Annotations.Length != 0)
                    .AddStringParameter("overview", Overview, () => Overview != DefaultOverview)
                    .AddParams("timestamps", Timestamps.Select(x => x.ToString()).ToArray())
                    .AddBoolParameter("tidy", Tidy, false)
                    .AddStringParameter("gaps", Gaps, () => Gaps != DefaultGaps);

                return urlParams;
            }
        }
    }
}