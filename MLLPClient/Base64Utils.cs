﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLLPClient
{

    public class Base64Utils
    {

        public void Execute()
        {
            string rawData = @"MSH|^~\&|ADTApp|GHHSFacility^2.16.840.1.122848.1.30^ISO|EHRApp^1.Edu^ISO|GHHRFacility^2.16.840.1.1122848.1.32^ISO|198908181126+0215|SECURITY|ADT^A01^ADT_A01|MSG00001|P|2.8|||||USA||en-US|||22 GHH Inc.|23 GHH Inc.|24GHH^2.16.840.1.114884.10.20^ISO|25GHH^2.16.840.1.114884.10.23^ISO
EVN|A01|20290801070624+0115|20290801070724|01^Patient request^HL70062|C08^Woolfson^Kathleen^2ndname^Jr^Dr^MD^^DRNBR&1.3.6.1.4.1.44750.1.2.2&ISO^L^^^ANON|20210817151943.4+0200|Cona_Health^1.3.6.1.4.1.44750.1.4^ISO
PID|1|1234567^4^M11^test^MR^University Hospital^19241011^19241012|PATID1234^5^M11^test1&2.16.1&HCD^MR^GOOD HEALTH HOSPITAL~123456789^^^USSSA^SS|PATID567^^^test2|EVERYMAN&&&&Aniston^ADAM^A^III^Dr.^MD^D^^^19241012^^^^PF^Addsm~Josh&&&&Bing^^stanley^^^^L^^^^^19241010^19241015|SMITH^Angela^L|198808181126+0215|M|elbert^Son|2106-3^White^HL70005~2028-9^Asian^HL70005|1000&Hospital Lane^Ste. 123^Ann Arbor ^MI^99999^USA^M^^&W^^^20000110&20000120^^^^^^^Near Highway|GL|78788788^^CP^5555^^^1111^^^^^2222^20010110^20020110^^^^18~12121212^^CP|7777^^CP~1111^^TDD|ara^^HL70296^eng^English-us^HL70296^v2^v2.1^TextInEnglish|M^Married|AME|4000776^^^AccMgr&1.3.6.1.4.1.44750.1.2.2&ISO^VN^1^19241011^19241012|PSSN123121234|DLN-123^US^20010123|1212121^^^NTH&rt23&HCD^AND^^19241011^19241012|N^NOT HISPANIC OR LATINO^HL70189|St. Francis Community Hospital of Lower South Side|N|2|US^United States of America^ISO3166_1|Vet123^retired^ART|BT^Bhutan^ISO3166_1|20080825111630+0115|Y|||20050110015014+0315||125097000^Goat^SCT|4880003^Beagle^SCT|||CA^Canada^ISO3166_1|89898989^WPN^Internet
PV1|1|P|HUH AE OMU&9.8&ISO^OMU B^Bed 03^HOMERTON UNIVER^^C^Homerton UH^Floor5|E|1234567^4^M11^t&2.16.840.1.113883.19&HCD^ANON^University Hospital^19241011^19241012|4 East, room 136, bed B 4E^136^B^CommunityHospital^^N^^^|1122334^Alaz^Mohammed^Mahi^JR^Dr.^MD^^PERSONNELt&1.23&HCD^B^^^BR^^^^^^19241010^19241015^Al|C006^Woolfson^Kathleen^^^Dr^^^TEST&23.2&HCD^MSK^^^BA|C008^Condoc^leen^^^Dr^^^&1.3.6.1.4.1.44750.1.2.2&ISO^NAV^^^BR|SUR|||R|NHS Provider-General (inc.A\T\E-this Hosp)||VIP^Very Important Person^L^IMP^^DCM^v1.1^v1.2^Inportant Person|37^DISNEY^WALT^^^^^^AccMgr^^^^ANC|Inpatient|40007716^^^AccMng&1.2&HCD^AM|||||||||||||||||Admitted as Inpatient^Sample^ACR|22&Homes&FDK|Vegan^Vegetarian|HOMERTON UNIVER||Active|POC^Room-2^Bed-103^^^C^Greenland|Nursing home^^^^^^Rosewood|20150208113419+0110||||||50^^^T123&1.3.6.1.4.1.44750.1.2.2&ISO^MR||Othhel^^^^^^^^testing&&HCD||EOC124^5^M11^Etest&2.16.1&HCD^MR^CommunityHospital";



            string b64 = Base64Encode(rawData);

            List<string> listBase64 = b64.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] aryBase64 = listBase64.ToArray();
            string b64Orig = String.Join("\r\n", aryBase64);
            string backToRawData = Base64Decode(b64Orig);

            Console.WriteLine("check");

        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes, Base64FormattingOptions.InsertLineBreaks);
        }
        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

}
