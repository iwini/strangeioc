/// MainContext maps the Context for the top-level component.
/// ===========
/// I'm assuming here that you've already gone through myfirstproject, or that
/// you're experienced with Babel.

using System;
using UnityEngine;
using babel.extensions.context.api;
using babel.extensions.context.impl;
using babel.extensions.dispatcher.eventdispatcher.api;
using babel.extensions.dispatcher.eventdispatcher.impl;

namespace babel.examples.multiplecontexts.game
{
	public class GameContext : MVCSContext
	{
		
		
		public GameContext () : base()
		{
		}
		
		public GameContext (MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
		{
		}
		
		protected override void mapBindings()
		{
			injectionBinder.Bind<IScore>().To<ScoreModel>().AsSingleton();
			
			mediationBinder.Bind<ShipView>().To<ShipMediator>();
			mediationBinder.Bind<EnemyView>().To<EnemyMediator>();
			mediationBinder.Bind<ScoreboardView>().To<ScoreboardMediator>();
			
			sequencer.Bind(ContextEvent.START).To<StartAppCommand>().To<StartGameCommand>().Once();
			
			commandBinder.Bind(GameEvent.ADD_TO_SCORE).To<UpdateScoreCommand>();
			commandBinder.Bind(GameEvent.SHIP_DESTROYED).To<ShipDestroyedCommand>();
			commandBinder.Bind(GameEvent.GAME_OVER).To<GameOverCommand>();
			commandBinder.Bind(GameEvent.REPLAY).To<ReplayGameCommand>();
		}
	}
}

