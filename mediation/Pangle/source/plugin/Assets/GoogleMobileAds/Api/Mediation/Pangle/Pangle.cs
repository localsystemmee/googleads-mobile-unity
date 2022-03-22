// Copyright 2022 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;

using GoogleMobileAds.Common.Mediation.Pangle;
using GoogleMobileAds.Mediation;

namespace GoogleMobileAds.Api.Mediation.Pangle
{

    public class Pangle
    {
        public static readonly IPangleClient client = GetPangleClient();

        private static IPangleClient GetPangleClient()
        {
            return PangleClientFactory.PangleInstance();
        }

        /// <summary>
        /// Set the GDPR setting in Pangle SDK.
        /// </summary>
        /// <remarks>
        /// Pangle SDK can only accept the following values: [-1, 0, 1]
        /// </remarks>
        /// <param name="gdpr">
        /// An <c>int</c> value that indicates whether the user consents the use of personal data to serve ads under GDPR.
        /// </param>
        public static void SetGDPR(int gdpr)
        {
            if (gdpr != 0 && gdpr != 1 && gdpr != -1)
            {
                Debug.Log("Invalid GDPR value. Pangle SDK only accepts -1, 0 or 1.");
                return;
            }
            client.SetGDPR(gdpr);
        }

        /// <summary>
        /// Set the CCPA setting in Pangle SDK.
        /// </summary>
        /// <remarks>
        /// Pangle SDK can only accept the following values: [-1, 0, 1]
        /// </remarks>
        /// <param name="ccpa">
        /// An <c>int</c>  value that indicates whether the user opts in of the "sale" of the "personal information" under CCPA.
        /// </param>
        public static void SetCCPA(int ccpa)
        {
            if (ccpa != 0 && ccpa != 1 && ccpa != -1)
            {
                Debug.Log("Invalid CCPA value. Pangle SDK only accepts -1, 0 or 1.");
                return;
            }
            client.SetCCPA(ccpa);
        }
    }
}
