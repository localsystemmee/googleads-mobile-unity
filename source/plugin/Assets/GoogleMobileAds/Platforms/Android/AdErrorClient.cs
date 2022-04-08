// Copyright (C) 2021 Google LLC
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

using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
    internal class AdErrorClient : IAdErrorClient
    {
        AndroidJavaObject error;
        int code;
        string domain;
        string message;
        string description;
        AdErrorClient inner;

        public AdErrorClient(AndroidJavaObject error)
        {
            this.error = error;

            // Because JNI objects are weak references and may be released,
            // we cache the members for use in case we access this object later.
            this.code = error.Call<int>("getCode");
            this.domain = error.Call<string>("getDomain");;
            this.message = error.Call<string>("getMessage");;
            this.description = error.Call<string>("toString");
            AndroidJavaObject cause = error.Call<AndroidJavaObject>("getCause");
            if (cause != null)
            {
              this.inner = new AdErrorClient(cause);
            }
        }
        public int GetCode()
        {
           return code;
        }
        public string GetDomain()
        {
            return domain;
        }

        public string GetMessage()
        {
            return message;
        }

        public IAdErrorClient GetCause()
        {
            return inner;
        }

        public override string ToString()
        {
            return description;
        }

    }
}
