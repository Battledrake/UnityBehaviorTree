# Unity Behavior Tree with Visual Node Graph.

#### Based on the behavior tree created by the youtuber TheKiwiCoder with a blackboard design from the youtuber git-amend. 

![BlackboardData](https://github.com/Battledrake/BehaviorTree/assets/37988801/8a1c2d79-c5b4-44ec-9e0a-15ac3eeaf017)
![RunningTree](https://github.com/Battledrake/BehaviorTree/assets/37988801/d33447b2-807d-4b0f-ba53-a26198bc7a23)


**Additional Features:**
- Root Node can't be deleted and is callback added to the behavior tree instance once during creation. This prevents asset addition errors by ensuring asset is finished being created before attempting to add root instance.
- Undo and Redo working completely.
- description override on each node to display data during evaluations.
- Create Tree Dialog with cancel option.
- Graph refresh on asset deletion.
- Dropped edges now display a context menu to quickly add a node. (Note: Does not auto connect)
- Added display time for node results for debugging tree by showing and hiding result borders instead of just leaving them on.
- Code is fully encapsulated.
- Fully functional and well-written Blackboard system with custom editor to add/modify scriptable blackboard data assets.
- Small demo showcasing basic functionality tree with blackboard values being set and retrieved.

**Based on:**
- https://youtu.be/SgrG6uAZDHE?si=fTfwaWPsM7MAsN2j Showcase

**Tutorials:**
- https://youtu.be/nKpM98I7PeM?si=oYcoF8oI_yfa9eFJ Tutorial 1
- https://youtu.be/jhB_GFgS6S0?si=NftExODh4PvnJowd Tutorial 2

**Blackboard System:**
- https://youtu.be/HNGJ8KOqdYQ?si=soeaQwnbQcUeqixA


### Adding new blackboard value types quick walkthrough:
- BlackboardData Script
  - Add new enum value to ValueType enum inside AnyValue
  - Add a public member field of the type you want to add
  - Add an implicit operator. Just copy/paste existing and change type
  - Add to ConvertValue with (T)(object) like other non primitive examples.
  - Add to setValueDispatchTable under BlackboardEntryData. Copy from existing and replace type.
- BlackboardDataEditor Script
  - Add new type to switch statement. Use existing examples and replace type.
- CompareBBEntries Script
  - Add new type to switch statement

### Blackboard Breakdown:
- Dictionary based with BlackboardKey type for key and object value with BlackboardEntry underlying type.
- strings can be converted to valid keys with GetOrRegisterKey(string key).
  - This will create a new key in the blackboard with an empty value or retrieve an existing one.
- Set values with SetValue(BlackboardKey key, T value) with T being a valid valuetype from the above steps.
- Retrieve values with TryGetValue(BlackboardKey, out T value). Invalid keys return false.
- Asset Menu to create Blackboard Data scriptable objects that can be filled with needed keys and values.
  - Blackboard Data assets are to be added to a Behavior Tree scriptable object. The behavior tree is to be added to a Behavior Tree Runner component.
    - The data will be passed into the blackboard of that behavior tree during the data binding stage which is called by the Behavior Tree Runner Component.

  
