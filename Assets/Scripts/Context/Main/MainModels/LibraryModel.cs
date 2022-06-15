using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class LibraryModel<TC> where TC : Config
{
	private List<TC> _libraryData = new List<TC>();

	public void Initialize(IEnumerable<TC> libraryData)
	{
		_libraryData = libraryData.ToList();
	}


	public TC GetLibraryDataById(string id)
	{
		var config = _libraryData.FirstOrDefault(e => e.Id.Equals(id));

		return config;
	}
}
