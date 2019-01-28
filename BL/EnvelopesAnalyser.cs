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

        private const string ENVELOPES_NOT_PLAСEABLE = "Objects can't be plased in each other ";
        private const string IS_IN = " is in ";

        #endregion
        
        private bool CanPlaceOneEnvelopeInOther(Envelope pushedEnvelope, Envelope targetEnvelope)
        {
            bool isOk = false;
            if (pushedEnvelope.CompareTo(targetEnvelope) == 1)
            {
                isOk = true;
            }
            else if (IsReversedSidesPlaceable(pushedEnvelope, targetEnvelope))
            {
                isOk = true;
            }
            return isOk;
        }

        private bool IsReversedSidesPlaceable(Envelope pushedEnvelope, Envelope targetEnvelope)
        {
            Envelope sidesChangedEnvelope = new Envelope(targetEnvelope.Length, targetEnvelope.Width);

            return (pushedEnvelope.CompareTo(sidesChangedEnvelope) == 1);
            
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
                    message = ENVELOPES_NOT_PLAСEABLE + first.ToString() + second.ToString();
                }
            }

            return message;

        }

    }
}
