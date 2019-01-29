using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resourses;


namespace EnvelopBL
{
    public class EnvelopesAnalyser
    {
        public CompareResult CompareEnvelopes(Envelope first, Envelope second)
        {

            if (first == null || second == null)
            {

                return CompareResult.AreEmpty;
            }

            return GetEnvelopeComparisonResult(first, second);
        }

        private CompareResult GetEnvelopeComparisonResult(Envelope first, Envelope second)
        {
           
            if (CanPlaceOneEnvelopeInOther(first, second))
            {

                return CompareResult.FirstInSecond;
            }
            else if (CanPlaceOneEnvelopeInOther(second, first))
            {

                return CompareResult.SecondInFirst;
            }
            else
            {

                return CompareResult.NotComparable;
            }
        }

        private bool CanPlaceOneEnvelopeInOther(Envelope pushedEnvelope, Envelope targetEnvelope)
        {

            return ((pushedEnvelope.CompareTo(targetEnvelope) == 1)
                || (IsReversedSidesPlaceable(pushedEnvelope, targetEnvelope)));
        }

        private bool IsReversedSidesPlaceable(Envelope pushedEnvelope, Envelope targetEnvelope)
        {
            Envelope sidesChangedEnvelope = new Envelope(targetEnvelope.Length, targetEnvelope.Width);

            return (pushedEnvelope.CompareTo(sidesChangedEnvelope) == 1);

        }

    }
}
