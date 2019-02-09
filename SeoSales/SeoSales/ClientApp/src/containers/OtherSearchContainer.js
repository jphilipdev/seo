import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { otherResults, otherSearchError } from '../store/selectors/searchSelectors';
import { searchOther } from '../store/thunks/searchThunks';
import OtherSearch from '../components/search/OtherSearch';

const mapStateToProps = state => ({
  otherResults: otherResults(state),
  otherSearchError: otherSearchError(state)
});

const mapDispatchToProps = dispatch => bindActionCreators({
  searchOther
}, dispatch)

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(OtherSearch);