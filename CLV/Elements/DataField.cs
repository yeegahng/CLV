/*
 * Created by SharpDevelop.
 * User: ygsong
 * Date: 2015-12-29
 * Time: 오후 3:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CLV
{
	/// <summary>
	/// Description of DataField.
	/// </summary>
	public class DataField
	{
		private String fieldName;
		private int fieldDataLength;
		private String fieldData;
		
		public String FieldName
		{
			get
			{
				return fieldName;
			}
		}
		
		public int FieldDataLength
		{
			get
			{
				return fieldDataLength;
			}
		}
		
		public String FieldData
		{
			get
			{
				return fieldData;
			}
		}
		
		public DataField(String name, int dataLength)
		{
			this.fieldName = name;
			this.fieldDataLength = dataLength;
		}
		
		public DataField(String name, String data)
		{
			this.fieldName = name;
			this.fieldData = data;
		}
	}
	
}
