﻿package  {	import flash.display.MovieClip;	public class State extends MovieClip{		private var _base:MovieClip		public function State() {		}		public function set base(b:MovieClip){			this._base = b		}		public function get base():MovieClip{			return _base;					}	}	}