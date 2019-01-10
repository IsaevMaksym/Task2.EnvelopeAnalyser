using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class EnvelopesAnalyser
    {
        #region Constants

        public const string ENVELOPES_NOT_PLAСEABLE = "Objects can't be plased in each other";
        public const string IS_IN = "is in";

        #endregion


        private bool CanPlaceOneEnvelopeInOther(Envelope targetEnvelope, Envelope pushedEnvelope)
        {
            bool isOk = false;
            if (targetEnvelope.CompareTo(pushedEnvelope) == 1)
            {
                isOk = true;
            }
            else if (IsReversedSidesPlaceable(targetEnvelope, pushedEnvelope))
            {
                isOk = true;
            }
            return isOk;
        }

        private bool IsReversedSidesPlaceable(Envelope targetEnvelope, Envelope pushedEnvelope)
        {
            bool isOk = false;

            Envelope sidesChangedEnvelope = new Envelope(pushedEnvelope.Length, pushedEnvelope.Width);

            if (targetEnvelope.CompareTo(sidesChangedEnvelope) == 1)
            {
                isOk = true;
            }

            return isOk;
        }

        public string CompareEnvelopes(Envelope first, Envelope second)
        {
            string message = "";
            if (first == null || second == null)
            {
                message = "One or more objects is null";
            }

            else
            {
                if (CanPlaceOneEnvelopeInOther(first, second))
                {
                    message = first.ToString() + IS_IN + second.ToString();
                }
                else if (CanPlaceOneEnvelopeInOther(second, first))
                {
                    message = second.ToString() + IS_IN + first.ToString();
                }
                else
                {
                    message = ENVELOPES_NOT_PLAСEABLE;
                }
            }

            return message;

        }

    }
}
