/* 
 * Strava API v3
 *
 * The [Swagger Playground](https://developers.strava.com/playground) is the easiest way to familiarize yourself with the Strava API by submitting HTTP requests and observing the responses before you write any client code. It will show what a response will look like with different endpoints depending on the authorization scope you receive from your athletes. To use the Playground, go to https://www.strava.com/settings/api and change your “Authorization Callback Domain” to developers.strava.com. Please note, we only support Swagger 2.0. There is a known issue where you can only select one scope at a time. For more information, please check the section “client code” at https://developers.strava.com/docs.
 *
 * OpenAPI spec version: 3.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Zones
    /// </summary>
    [DataContract]
    public partial class Zones :  IEquatable<Zones>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Zones" /> class.
        /// </summary>
        /// <param name="heartRate">heartRate.</param>
        /// <param name="power">power.</param>
        public Zones(HeartRateZoneRanges heartRate = default(HeartRateZoneRanges), PowerZoneRanges power = default(PowerZoneRanges))
        {
            this.HeartRate = heartRate;
            this.Power = power;
        }
        
        /// <summary>
        /// Gets or Sets HeartRate
        /// </summary>
        [DataMember(Name="heart_rate", EmitDefaultValue=false)]
        public HeartRateZoneRanges HeartRate { get; set; }

        /// <summary>
        /// Gets or Sets Power
        /// </summary>
        [DataMember(Name="power", EmitDefaultValue=false)]
        public PowerZoneRanges Power { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Zones {\n");
            sb.Append("  HeartRate: ").Append(HeartRate).Append("\n");
            sb.Append("  Power: ").Append(Power).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Zones);
        }

        /// <summary>
        /// Returns true if Zones instances are equal
        /// </summary>
        /// <param name="input">Instance of Zones to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Zones input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.HeartRate == input.HeartRate ||
                    (this.HeartRate != null &&
                    this.HeartRate.Equals(input.HeartRate))
                ) && 
                (
                    this.Power == input.Power ||
                    (this.Power != null &&
                    this.Power.Equals(input.Power))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.HeartRate != null)
                    hashCode = hashCode * 59 + this.HeartRate.GetHashCode();
                if (this.Power != null)
                    hashCode = hashCode * 59 + this.Power.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
