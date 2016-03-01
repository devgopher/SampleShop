/*
 * User: igor.evdokimov
 * Date: 01.03.2016
 * Time: 15:38
 */
using System;
using System.Runtime.Serialization;

namespace SampleShopClient
{
	/// <summary>
	/// Description of SampleShopClientException.
	/// </summary>
	public class SampleShopClientException : Exception, ISerializable
	{
		public SampleShopClientException()
		{
		}

	 	public SampleShopClientException(string message) : base(message)
		{
		}

		public SampleShopClientException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected SampleShopClientException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}