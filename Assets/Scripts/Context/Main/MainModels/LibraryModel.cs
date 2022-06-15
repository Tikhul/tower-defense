using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class LibraryModel<TC> where TC : ScriptableObject
{
	private List<TC> _libraryData = new List<TC>();

	public void Initialize(IEnumerable<TC> libraryData)
	{
		_libraryData = libraryData.ToList();
	}

	public IEnumerable<TC> GetAllLibraryData()
	{
		return _libraryData;
	}
}
